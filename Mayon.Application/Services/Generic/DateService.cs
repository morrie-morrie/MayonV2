using Mayon.Application.Services.Interfaces;
using Serilog;

namespace Mayon.Application.Services.Generic;
public class DateService : IDateService
{
    public string GetDateUTC()
    {
        return DateTime.UtcNow.ToString("ddd, dd MMM yyyy HH:mm:ss -0000");
    }

    public string? FormatUnixTime(double? unixTime)
    {
        if (!unixTime.HasValue)
        {
            // Handle null case explicitly
            return null; // or some default value if preferred
        }

        try
        {
            long unixTimeAsLong = (long)unixTime;
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTimeAsLong);

            return dateTimeOffset.ToString("dd-MM-yyyy HH:mm:ss");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            // Log the exception details using Serilog
            Log.Error(ex, "Failed to format Unix time {UnixTime}", unixTime);

            // Return null or a default value
            return null;
        }
    }
}