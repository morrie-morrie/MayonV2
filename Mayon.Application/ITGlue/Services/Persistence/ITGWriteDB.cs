using Mayon.Application.Entities.ITGlue;
using Mayon.Application.Entities.ITGlue.Infra;
using Mayon.Application.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Mayon.Application.ITGlue.Services.Persistence;

public static class ItgWriteDb
{
    public static void WriteITGOrgsToDB(IEnumerable<ITGOrgData> itgOrgsResponse)
    {
        using var db = new AppDbContext();
        var existingOrgs = db.ITGOrganisations.AsNoTracking().ToList();
        foreach (var org in itgOrgsResponse)
        {
            var infraOrg = new InfraITGOrganisations
            {
                OrgId = org.Id,
                Name = org.Attributes.Name,
                alert = org.Attributes.Alert,
                description = org.Attributes.Description,
                OrganizationTypeId = org.Attributes.OrganizationTypeId,
                OrganizationTypeName = org.Attributes.OrganizationTypeName,
                OrganizationStatusId = org.Attributes.OrganizationStatusId,
                OrganizationStatusName = org.Attributes.OrganizationStatusName,
                primary = org.Attributes.Primary,
                QuickNotes = org.Attributes.QuickNotes,
                ShortName = org.Attributes.ShortName,
                CreatedAt = org.Attributes.CreatedAt,
                UpdatedAt = org.Attributes.UpdatedAt
            };
            var existingOrg = existingOrgs.Find(o => o.Id == infraOrg.Id);
            if (existingOrg != null)
            {
                db.Entry(infraOrg).State = EntityState.Modified;
            }
            else
            {
                db.ITGOrganisations.Add(infraOrg);
            }
        }
        var currentITGOrgs = itgOrgsResponse.Select(o => o.Id).ToList();
        var itgOrgsToRemove = existingOrgs.Where(t => !currentITGOrgs.Contains(t.Id));
        db.ITGOrganisations.RemoveRange(itgOrgsToRemove);
        db.SaveChanges();
        Log.Logger.Information("Successfully wrote {itgOrgsResponseCount} ITGOrg(s) to database.", itgOrgsResponse.Count());
    }
}