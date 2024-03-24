using Konscious.Security.Cryptography;
using Serilog;
using System.Security.Cryptography;
using System.Text;

namespace Mayon.Application.Services.Generic;
public class PasswordServices

{
    private static readonly RandomNumberGenerator rng = RandomNumberGenerator.Create();

    public static byte[] CreateSalt(int length = 32)
    {
        var buffer = new byte[length];
        rng.GetBytes(buffer);
        return buffer;
    }

    public static byte[] HashPassword(string password, byte[] salt)
    {
        try
        {
            using (var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password)))
            {
                argon2.Salt = salt;
                argon2.DegreeOfParallelism = 8; // Four cores
                argon2.Iterations = 4;
                argon2.MemorySize = 1024 * 1024; // 1 GB

                return argon2.GetBytes(16);
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Password hashing error");
            throw;
        }
    }

    public static bool VerifyHash(string password, byte[] salt, byte[] hash)
    {
        var newHash = HashPassword(password, salt);
        return hash.SequenceEqual(newHash);
    }

    public static byte[] Encrypt(string input, byte[] key)
    {
        try
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;  // Using the provided key
                aes.GenerateIV();

                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                    byte[] encrypted = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                    byte[] result = new byte[aes.IV.Length + encrypted.Length];
                    Buffer.BlockCopy(aes.IV, 0, result, 0, aes.IV.Length);
                    Buffer.BlockCopy(encrypted, 0, result, aes.IV.Length, encrypted.Length);

                    return result;
                }
            }
        }
        catch (CryptographicException ex)
        {
            Log.Error($"Encryption error: {ex.Message}");
            throw;
        }
    }

    public static string Decrypt(byte[] input, byte[] key, PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        try
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.Padding = paddingMode;  // Use provided padding mode

                byte[] iv = new byte[aes.BlockSize / 8];
                byte[] encrypted = new byte[input.Length - iv.Length];
                Buffer.BlockCopy(input, 0, iv, 0, iv.Length);
                Buffer.BlockCopy(input, iv.Length, encrypted, 0, encrypted.Length);
                aes.IV = iv;

                using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                using (MemoryStream ms = new MemoryStream(encrypted))
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (StreamReader sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        catch (CryptographicException ex)
        {
            Log.Error($"Decryption error: {ex.Message}");
            throw;
        }
    }

    public static byte[] GenerateKey(int length)
    {
        if (length != 16 && length != 24 && length != 32)
        {
            Log.Error("Length must be either 16, 24, or 32 bytes");
            throw new ArgumentException("Length must be either 16, 24, or 32 bytes", nameof(length));
        }

        var key = new byte[length];
        rng.GetBytes(key);
        return key;
    }
}