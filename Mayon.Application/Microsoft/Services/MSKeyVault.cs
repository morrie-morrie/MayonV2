using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System.Security.Cryptography.X509Certificates;

public class KeyVaultService
{
    private static SecretClient secretClient;

    public KeyVaultService(string keyVaultUrl, string tenantId, string clientId, string thumbprint)
    {
        if (secretClient == null)
        {
            secretClient = InitializeClientWithCertificate(keyVaultUrl, tenantId, clientId, thumbprint)
                           ?? InitializeClientWithInteractiveCredentials(keyVaultUrl, tenantId, clientId);
        }
    }

    private SecretClient InitializeClientWithCertificate(string keyVaultUrl, string tenantId, string clientId, string thumbprint)
    {
        using (X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser))
        {
            store.Open(OpenFlags.ReadOnly);
            var certificates = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
            if (certificates.Count > 0)
            {
                var certificate = certificates[0];
                var credential = new ClientCertificateCredential(tenantId, clientId, certificate);
                return new SecretClient(new Uri(keyVaultUrl), credential);
            }
            else
            {
                throw new InvalidOperationException("Certificate not found.");
            }
        }
    }

    private SecretClient InitializeClientWithInteractiveCredentials(string keyVaultUrl, string tenantId, string clientId)
    {
        var sharedTokenCacheOptions = new SharedTokenCacheCredentialOptions
        {
            TenantId = tenantId,
            ClientId = clientId
        };
        var sharedCredential = new SharedTokenCacheCredential(sharedTokenCacheOptions);

        var interactiveOptions = new InteractiveBrowserCredentialOptions
        {
            TenantId = tenantId,
            ClientId = clientId,
            RedirectUri = new Uri("http://localhost") // Ensure this matches your Azure AD app registration
        };
        var interactiveCredential = new InteractiveBrowserCredential(interactiveOptions);

        var credential = new ChainedTokenCredential(sharedCredential, interactiveCredential);
        return new SecretClient(new Uri(keyVaultUrl), credential);
    }

    public async Task SetSecretAsync(string secretName, string secretValue)
    {
        try
        {
            await secretClient.SetSecretAsync(secretName, secretValue);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error setting secret: {ex.Message}");
            throw;
        }
    }

    public async Task<string> GetSecretAsync(string secretName)
    {
        try
        {
            if (string.IsNullOrEmpty(secretName))
            {
                throw new ArgumentException("Secret name cannot be null or empty", nameof(secretName));
            }

            KeyVaultSecret secret = await secretClient.GetSecretAsync(secretName);
            return secret.Value;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving secret: {ex.Message}");
            throw;
        }
    }

    public async Task<SecretClient> GetKeyVaultClientWithCertificate(string keyVaultUrl, string tenantId, string clientId, string thumbprint)
    {
        if (CheckCertificateExists(thumbprint))
        {
            using (X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser))
            {
                store.Open(OpenFlags.ReadOnly);
                var certificates = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);

                if (certificates.Count > 0)
                {
                    var certificate = certificates[0];
                    var credential = new ClientCertificateCredential(tenantId, clientId, certificate);
                    return new SecretClient(new Uri(keyVaultUrl), credential);
                }
            }
        }

        throw new InvalidOperationException("Certificate not found.");
    }

    private bool CheckCertificateExists(string thumbprint)
    {
        using (X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser))
        {
            store.Open(OpenFlags.ReadOnly);
            var certificates = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
            return certificates.Count > 0;
        }
    }

    public SecretClient GetSecretClient()
    {
        return secretClient;
    }
}