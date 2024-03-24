namespace Mayon.Application.Services.Interfaces;

public interface IDateService
{
    string GetDateUTC();

    string? FormatUnixTime(double? unixTime);
}