namespace Mayon.Application.Entities.Webroot;

public class WebrootSiteResponse
{
    public int TotalSeatsAllowed { get; set; }
    public string ParentDescription { get; set; }
    public int SumTotalDevices { get; set; }
    public int SumTotalDevicesAllowed { get; set; }
    public int SumTotalDevicesNotTrial { get; set; }
    public int SumTotalMobileDevicesAllowed { get; set; }
    public int TotalCount { get; set; }
    public Site[] Sites { get; set; }

    public class Site
    {
        public string SiteId { get; set; }
        public string SiteName { get; set; }
        public string SiteType { get; set; }
        public int TotalEndpoints { get; set; }
        public int PCsInfected24 { get; set; }
        public string AccountKeyCode { get; set; }
        public int DevicesAllowed { get; set; }
        public int MobileSeats { get; set; }
        public bool Deactivated { get; set; }
        public bool Suspended { get; set; }
        public DateTime EndDate { get; set; }
        public bool Device { get; set; }
        public bool Infect { get; set; }
        public string BillingCycle { get; set; }
        public string BillingDate { get; set; }
        public string CompanyComments { get; set; }
        public string DeactivatedBy { get; set; }
        public string SuspendedBy { get; set; }
        public string CreatedBy { get; set; }
        public bool GlobalPolicies { get; set; }
        public bool GlobalOverrides { get; set; }
        public bool GlobalAlerts { get; set; }
        public bool AllKeysExpired { get; set; }
        public string Description { get; set; }
        public string PolicyId { get; set; }
        public string PolicyName { get; set; }
        public string PolicyDescription { get; set; }
        public object Emails { get; set; }
        public int AccessLevel { get; set; }
        public object[] Modules { get; set; }
    }
}