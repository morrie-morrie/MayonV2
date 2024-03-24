using CsvHelper;
using EFCore.BulkExtensions;
using Mayon.Application.Entities.Microsoft.Helper;
using Mayon.Application.Entities.Microsoft.Infra.Helper;
using Mayon.Application.Services;

namespace Mayon.Application.Microsoft.Graph.Helper;
public static class MSSkuHelper
{
    public static void GetMSSkuFriendlyName()
    {
        try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Starting GetMSSkuFriendlyName...");

            using var client = new HttpClient();
            Console.WriteLine("Fetching CSV data...");

            HttpResponseMessage response = client.GetAsync("https://download.microsoft.com/download/e/3/e/e3e9faf2-f28b-490a-9ada-c6089a1fc5b0/Product%20names%20and%20service%20plan%20identifiers%20for%20licensing.csv").Result;

            using var reader = new StringReader(response.Content.ReadAsStringAsync().Result);
            using var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);
            var records = csv.GetRecords<MSSkuFriendly.MSFriendlySKU>();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Processing records...");
            Console.ResetColor();

            using var _db = new AppDbContext();
            Console.WriteLine("Clearing existing data...");

            // Clear the table
            _db.InfraFriendlySkus.RemoveRange(_db.InfraFriendlySkus);
            _db.SaveChanges();

            // Create a list of InfraFriendlySkus to hold your new records
            var infraFriendlySkus = new List<InfraFriendlySkus>();

            foreach (var record in records)
            {
                var infraFriendlySku = new InfraFriendlySkus
                {
                    MSSkuDisplayName = record.Product_Display_Name,
                    MSSkuStringId = record.String_Id,
                    MSSkuGUID = record.GUID,
                    MSSkuServicePlanName = record.Service_Plan_Name,
                    MSSkuServicePlanId = record.Service_Plan_Id,
                    MSSkuFriendlyName = record.Service_Plans_Included_Friendly_Names,
                };

                // Add the new infraFriendlySku to the list
                infraFriendlySkus.Add(infraFriendlySku);
            }

            Console.WriteLine("Inserting new records...");
            // Pass the list to the BulkInsert method
            _db.BulkInsert(infraFriendlySkus);
            Console.WriteLine("Records inserted successfully!");
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            // Log any exceptions that occur
            Console.WriteLine($"An error occurred: {ex.Message}\n{ex.StackTrace}");
        }
    }
}