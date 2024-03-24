using Mayon.Application.Duo.RestApi.Helpers;
using Mayon.Application.Entities.Duo;
using Mayon.Application.Entities.Duo.Infra;
using Mayon.Application.Services;
using Mayon.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System.Security.Cryptography;
using System.Text;

namespace Mayon.Application.Duo.RestApi;
public class DuoAuth
{
    private readonly IDateService _dateservice;

    public DuoAuth(IDateService dateservice)
    {
        _dateservice = dateservice;
    }

    public List<string>? GetAuthHeadersForAllCustomers(IConfiguration configuration)
    {
        using var db = new AppDbContext();
        var customers = db.DuoCustomers
            .OrderBy(a => a.DuoAccountId)
            .ToList();

        List<string> responseContents = new List<string>();

        foreach (var customer in customers)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(customer.DuoCustomerName);
            Console.WriteLine(customer.DuoAccountId);
            Console.ResetColor();

            var responseContent = GetAuthHeaderForCustomer(customer, configuration);
            responseContents.Add(responseContent);

            // Deserialize the JSON response content
            var duoUserResponse = JsonConvert.DeserializeObject<DuoUserResponse.Root>(responseContent);

            if (duoUserResponse?.Response == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Customers found.");
                Console.ResetColor();
                continue;
            }

            int customerUserCount = 0;

            // Print each user
            foreach (var user in duoUserResponse.Response)
            {
                Console.WriteLine($"Real Name: {user.RealName}");
                Console.WriteLine($"Username: {user.UserName}");
                Console.WriteLine($"User ID: {user.UserId}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"First Name: {user.FirstName}");
                Console.WriteLine($"Last Name: {user.LastName}");
                Console.WriteLine($"Status: {user.Status}");
                string? lastloginFormattedString = _dateservice.FormatUnixTime(user.LastLogin);
                Console.WriteLine($"Last Login: {lastloginFormattedString}");
                Console.WriteLine($"Alias1: {user.Alias1}");
                Console.WriteLine($"Alias2: {user.Alias2}");
                Console.WriteLine($"Alias3: {user.Alias3}");
                Console.WriteLine($"Alias4: {user.Alias4}");
                string? createdFormattedString = _dateservice.FormatUnixTime(user.Created);
                Console.WriteLine($"Created: {createdFormattedString}");
                foreach (var group in user.Groups)
                {
                    Console.WriteLine($"Group: {group.Name}");
                    Console.WriteLine($"GroupID: {group.GroupId}");
                    Console.WriteLine($"GroupStatus: {group.Status}");
                }
                string? lastDirectorySyncFormattedString = _dateservice.FormatUnixTime(user.LastDirectorySync);

                Console.WriteLine($"Last Directory Sync: {lastDirectorySyncFormattedString}");
                foreach (var phone in user.Phones)
                {
                    Console.WriteLine($"Phone Number: {phone.Number}");
                    Console.WriteLine($"Phone ID: {phone.PhoneId}");
                    Console.WriteLine($"Phone Extension: {phone.Extension}");
                    Console.WriteLine($"Phone Last Seen: {phone.LastSeen}");
                    Console.WriteLine($"Phone Platform: {phone.Platform}");
                    Console.WriteLine($"Phone Model: {phone.Model}");
                    Console.WriteLine($"Phone Activated? : {phone.Activated}");
                    foreach (var capability in phone.Capabilities)
                    {
                        Console.WriteLine($"Phone Capability: {capability}");
                    }
                }

                foreach (var token in user.Tokens)
                {
                    Console.WriteLine($"Token Serial: {token.Serial}");
                    Console.WriteLine($"Token Type: {token.Type}");
                    Console.WriteLine($"Tokens TOTP Step: {token.TotpStep}");
                }

                foreach (var webauthcreds in user.WebAuthnCredentials)
                {
                    Console.WriteLine($"WebAuth Serial: {webauthcreds.Serial}");
                    Console.WriteLine($"WebAuth Type: {webauthcreds.Type}");
                    Console.WriteLine($"WebAuth TOTP Step: {webauthcreds.TotpStep}");
                }

                Console.WriteLine();

                customerUserCount++;
            }
            Console.WriteLine();
            Console.WriteLine($"User count for {customer.DuoCustomerName}: {customerUserCount}");
            Console.WriteLine();
        }

        return responseContents;
    }

    public string GetAuthHeaderForCustomer(DuoCustomers customer, IConfiguration configuration)
    {
        var apihostname = configuration["APIs:Duo:ApiHostName"];
        var ikey = configuration["APIs:Duo:IntergrationKey"];
        var skey = configuration["APIs:Duo:SecretKey"]; ;
        var duoAccountId = customer.DuoAccountId;
        var endpoint = "/admin/v1/users";
        var requestParams = $"account_id={duoAccountId}";
        var httpMethod = "GET";
        var _dateAuth = _dateservice.GetDateUTC();

        var formattedParams = requestParams.Trim();
        var requestToSign = _dateAuth + "\n"
            + httpMethod.ToUpper() + "\n"
            + apihostname.ToLower().Trim() + "\n"
            + endpoint + "\n"
            + formattedParams;

        var requestToSignChar = requestToSign.ToCharArray();
        var requestToSignBytes = Encoding.UTF8.GetBytes(requestToSignChar);
        var hmacSHA1 = new HMACSHA1(Encoding.UTF8.GetBytes(skey));
        var authSignature = BitConverter.ToString(hmacSHA1.ComputeHash(requestToSignBytes)).Replace("-", "").ToLower();
        var authHeader = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", ikey, authSignature)));

        var client = new RestClient("https://" + apihostname);
        var request = new RestRequest($"/admin/v1/users?account_id={duoAccountId}", Method.Get);
        request.AddHeader("X-Duo-Date", _dateAuth);
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        request.AddHeader("Authorization", $"Basic {authHeader}");

        var response = client.Execute(request);

        if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
        {
            // Request was successful
            Console.WriteLine("Request successful");
        }
        else
        {
            // Request failed
            Console.WriteLine("Request failed with status code: " + response.StatusCode);
        }
        return response.Content ?? string.Empty;
    }
}