using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Security.KeyVault.Secrets;
using Mayon.Application.ITGlue.Helper;
using Mayon.Application.ITGlue.Services.Endpoints;
using Mayon.Application.Services;
using Mayon.Application.Webroot.Service;
using Mayon.Blazor.Components;
using Mayon.Blazor.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Console(
    outputTemplate: "{Message:lj}{NewLine}",
    theme: AnsiConsoleTheme.Code,
    restrictedToMinimumLevel: LogEventLevel.Information
    )
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddRazorPages();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Add Key Vault to configuration
var keyVaultUrl = Environment.GetEnvironmentVariable("KEYVAULT_ENDPOINT");
var tenantId = Environment.GetEnvironmentVariable("KV_TENANT_ID");
var clientId = Environment.GetEnvironmentVariable("KV_CLIENT_ID");
var thumbprint = Environment.GetEnvironmentVariable("KV_THUMBPRINT");

var keyVaultService = new KeyVaultService(keyVaultUrl, tenantId, clientId, thumbprint);
if (keyVaultService.GetSecretClient() is SecretClient secretClient)
{
    builder.Configuration.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());
}

// Correctly access the Syncfusion license key from configuration
var syncFusionLicenseKey = builder.Configuration["APIs:SyncFusion:Keycode"];
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(syncFusionLicenseKey);
builder.Services.AddSyncfusionBlazor();

builder.Services.AddHttpClient();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddITGlueService<ITGlueAPIOrganisations>("ITGlueClient");
builder.Services.AddITGlueService<ITGlueAPIConfigurations>("ITGlueClient");
builder.Services.AddITGlueService<ITGlueAPIDomains>("ITGlueClient");
builder.Services.AddITGlueService<ITGlueAPIUsers>("ITGlueClient");
builder.Services.AddWebrootService<WebrootServices>("WebrootClient");

builder.Services.AddMemoryCache();

// Add more services as needed

builder.Services.AddScoped<ITGAuth>();

HttpClientConfigurationManager.ConfigureClients(builder.Services, builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode();

app.Run();