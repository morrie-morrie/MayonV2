namespace Mayon.Application.Entities.Microsoft.Helper;

public class MSSkuFriendly
{
    public record MSFriendlySKU(

        string? Product_Display_Name,
        string? String_Id,
        string? GUID,
        string? Service_Plan_Name,
        string? Service_Plan_Id,
        string? Service_Plans_Included_Friendly_Names
    );
}