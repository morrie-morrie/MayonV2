# TODO List

####  SKU Licenses
https://learn.microsoft.com/en-us/azure/active-directory/enterprise-users/licensing-service-plan-reference

#### Below are all of the Graph calls I can find.
#### Probably duplicates.


- https://graph.microsoft.com/beta/deviceManagement/windowsAutopilotDeviceIdentities?`$top=999
- https://graph.microsoft.com/beta/tenantRelationships/managedTenants/managedDeviceCompliances
- https://graph.microsoft.com/beta/tenantRelationships/managedTenants/managedDeviceCompliances?`$top=999&`$filter=organizationId
- https://graph.microsoft.com/beta/deviceManagement/reports/getDeviceInstallStatusReport
- https://graph.microsoft.com/beta/deviceAppManagement/mobileApps?`$top=999&`$filter=(microsoft.graph.managedApp/appAvailability%20eq%20null%20or%20microsoft.graph.managedApp/appAvailability%20eq%20%27lineOfBusiness%27%20or%20isAssigned%20eq%20true)&`$orderby=displayName&
- https://graph.microsoft.com/beta/deviceManagement/windowsAutopilotDeploymentProfiles?`$expand=assignments
- https://graph.microsoft.com/beta/deviceManagement/deviceEnrollmentConfigurations?`$expand=assignments
- https://graph.microsoft.com/beta/organization
- https://graph.microsoft.com/beta/auditLogs/signIns?api-version=beta&filter=$($filters)
- https://graph.microsoft.com/beta/identity/conditionalAccess/policies
- https://graph.microsoft.com/beta/identity/conditionalAccess/namedLocations
- https://graph.microsoft.com/beta/applications
- https://graph.microsoft.com/beta/roleManagement/directory/roleDefinitions
- https://graph.microsoft.com/beta/groups
- https://graph.microsoft.com/beta/users
- https://graph.microsoft.com/beta/contacts/$($ContactID)?`$top=999&`$select=
- https://outlook.office365.com/ecp/@$TenantFilter/UsersGroups/EditContact.aspx?exsvurl=1&realm=$($env:TenantID)&mkt=en-US&id=$($_.id)
- https://graph.microsoft.com/beta/tenantRelationships/managedTenants/windowsProtectionStates?`$top=999&`$filter=tenantId
- https://api.securitycenter.microsoft.com/api/machines/SoftwareVulnerabilitiesByMachine?`$top=999 (Scope= https://api.securitycenter.microsoft.com/.default)

- https://graph.microsoft.com/beta/directory/deletedItems/microsoft.graph.$($Type)" ($Types = "Application", "User", "Device", "Group")
- https://graph.microsoft.com/beta/deviceManagement/managedDevices
- https://graph.microsoft.com/beta/domains
- Get-OutboundConnector
- Get-InboundConnector
- https://graph.microsoft.com/beta/tenantRelationships/findTenantInformationByDomainName(domainName='$Tenant'
- https://graph.microsoft.com/beta/tenantRelationships/managedTenants/inactiveUsers?`$count=true
- https://graph.microsoft.com/beta/deviceManagement/Intents?`$expand=settings,categories
- https://graph.microsoft.com/beta/deviceManagement/deviceConfigurations?`$select=id,displayName,lastModifiedDateTime,roleScopeTagIds,microsoft.graph.unsupportedDeviceConfiguration/originalEntityTypeName&`$expand=assignments&top=1000",
             "https://graph.microsoft.com/beta/deviceManagement/groupPolicyConfigurations?`$expand=assignments&top=1000"
             "https://graph.microsoft.com/beta/deviceAppManagement/mobileAppConfigurations?`$expand=assignments&`$filter=microsoft.graph.androidManagedStoreAppConfiguration/appSupportsOemConfig%20eq%20true"
             "https://graph.microsoft.com/beta/deviceManagement/configurationPolicies"
             "https://graph.microsoft.com/beta/deviceManagement/configurationPolicies?`$select=id,name,description,platforms,technologies,lastModifiedDateTime,settingCount,roleScopeTagIds,isAssigned&`$top=100&`$filter=(platforms%20eq%20%27windows10%27%20or%20platforms%20eq%20%27macOS%27)%20and%20(technologies%20eq%20%27mdm%27%20or%20technologies%20eq%20%27windows10XManagement%27)%20and%20(templateReference/templateFamily%20eq%20%27none%27)&`$expand=assignments"
- https://graph.microsoft.com/beta/subscribedSkus
                 Tenant         = $singlereq.Tenant
                 License        = $PrettyName
                 CountUsed      = "$($sku.consumedUnits)"
                 CountAvailable = $sku.prepaidUnits.enabled - $sku.consumedUnits
                 TotalLicenses  = "$($sku.prepaidUnits.enabled)"
                 skuId          = $sku.skuId
                 skuPartNumber  = $PrettyName
                 availableUnits = $sku.prepaidUnits.enabled - $sku.consumedUnits
 
- https://graph.microsoft.com/beta/users?$select=id,UserPrincipalName,DisplayName,accountEnabled
- https://graph.microsoft.com/v1.0/identity/conditionalAccess/policies
- https://graph.microsoft.com/beta/policies/identitySecurityDefaultsEnforcementPolicy
- https://graph.microsoft.com/beta/reports/credentialUserRegistrationDetails
                         Tenant          = "$tenantName"
                         UPN             = "$($_.UserPrincipalName)"
                         AccountEnabled  = [boolean]$AccountState
                         PerUser         = "$PerUser"
                         isLicensed      = "$($_.isLicensed)"
                         MFARegistration = [boolean]$MFARegUser
                         CoveredByCA     = [string]($UserCAState -join ', ')
                         CoveredBySD     = [boolean]$SecureDefaultsState
                         RowKey          = [string]($_.UserPrincipalName).replace('#', '')
                         PartitionKey    = 'users'
 						
- Get-QuarantineMessage
- https://outlook.office365.com/adminapi/beta/$($tenantfilter)/CasMailbox
- https://outlook.office365.com:443/adminapi/beta/$($TenantFilter)/mailbox('$($base64IdentityParam)')/MobileDevice/Exchange.GetMobileDeviceStatistics()/?IsEncoded=True"
- Get-Mailbox
- Get-InboxRule
- https://graph.microsoft.com/beta/reports/getMailboxUsageDetail(period='D7')
         @{ Name = 'displayName'; Expression = { $_.'Display Name' } },
         @{ Name = 'MailboxType'; Expression = { $_.'Recipient Type' } },
         @{ Name = 'LastActive'; Expression = { $_.'Last Activity Date' } },
         @{ Name = 'UsedGB'; Expression = { [math]::round($_.'Storage Used (Byte)' / 1GB, 2) } },
         @{ Name = 'QuotaGB'; Expression = { [math]::round($_.'Prohibit Send/Receive Quota (Byte)' / 1GB, 2) } },
         @{ Name = 'ItemCount'; Expression = { $_.'Item Count' } },
         @{ Name = 'HasArchive'; Expression = { If (($_.'Has Archive').ToLower() -eq 'true') { [bool]$true } else { [bool]$false } } }
 		
- https://graph.microsoft.com/beta/users/?`$top=999&`$select=id,userPrincipalName,assignedLicenses
- Get-MessageTraceDetail
- https://graph.microsoft.com/beta/servicePrincipals?`$select=id,displayName
- https://graph.microsoft.com/beta/oauth2PermissionGrants
- Get-AntiPhishRule
- Get-AntiPhishPolicy
- https://graph.microsoft.com/v1.0/directoryRoles?`$expand=members
- https://graph.microsoft.com/beta/admin/serviceAnnouncement/issues?`$filter=endDateTime eq null
- https://outlook.office365.com/adminapi/beta/$($TenantFilter)/Mailbox?`$filter=RecipientTypeDetails eq 'SharedMailbox'
- https://graph.microsoft.com/beta/admin/sharepoint/settings
- https://graph.microsoft.com/beta/auditLogs/signIns?api-version=beta&`$filter=$($filters)
- https://graph.microsoft.com/beta/reports/get$($type)Detail(period='D7')
-     $GraphRequest = $ParsedRequest | Select-Object @{ Name = 'UPN'; Expression = { $_.'Owner Principal Name' } },
     @{ Name = 'displayName'; Expression = { $_.'Owner Display Name' } },
     @{ Name = 'LastActive'; Expression = { $_.'Last Activity Date' } },
     @{ Name = 'FileCount'; Expression = { [int]$_.'File Count' } },
     @{ Name = 'UsedGB'; Expression = { [math]::round($_.'Storage Used (Byte)' / 1GB, 2) } },
     @{ Name = 'URL'; Expression = { $_.'Site URL' } },
     @{ Name = 'Allocated'; Expression = { [math]::round($_.'Storage Allocated (Byte)' / 1GB, 2) } },
     @{ Name = 'Template'; Expression = { $_.'Root Web Template' } }
 	
- Get-HostedContentFilterPolicy
- Get-HostedContentFilterRule
- https://graph.microsoft.com/beta/teams/$($TeamID)
- https://graph.microsoft.com/beta/teams/$($TeamID)/Channels
- https://graph.microsoft.com/beta/teams/$($TeamID)/Members
- htps://graph.microsoft.com/beta/teams/$($TeamID)/installedApps?`$expand=teamsAppDefinition
- https://graph.microsoft.com/beta/groups?`$filter=resourceProvisioningOptions/Any(x:x eq 'Team')&`$select=id,displayname,description,visibility,mailNickname
- https://graph.microsoft.com/beta/reports/get$($type)Detail(period='D30')
- https://graph.microsoft.com/beta/users?`$top=999&`$select=id,userPrincipalName,displayname
- https://api.interfaces.records.teams.microsoft.com/Skype.TelephoneNumberMgmt/Tenants/$($Tenantid)/telephone-numbers?locale=en-US
- Get-TransportRule
- https://main.iam.ad.ext.azure.com/api/Policies/Evaluate?
- https://graph.microsoft.com/beta/identity/conditionalAccess/policies
- https://graph.microsoft.com/beta/users?`$count=true&top=1
- https://graph.microsoft.com/beta/users?`$count=true&top=1&`$filter=assignedLicenses/`$count ne 0
- https://graph.microsoft.com/beta/roleManagement/directory/roleAssignments?`$filter=roleDefinitionId eq '62e90394-69f5-4237-9190-012177145e10'
- https://graph.microsoft.com/beta/users?`$count=true&top=1&`$filter=userType eq 'Guest'
   $EPMDevices = New-GraphGetRequest -uri "https://graph.microsoft.com/beta/users/$UserID/managedDevices" -Tenantid $tenantfilter
     $GraphRequest = New-GraphGetRequest -uri "https://graph.microsoft.com/beta/users/$UserID/ownedDevices?`$top=999" -Tenantid $tenantfilter  | Select-Object @{ Name = 'ID'; Expression = { $_.'id' } },
     @{ Name = 'accountEnabled'; Expression = { $_.'accountEnabled' } },
     @{ Name = 'approximateLastSignInDateTime'; Expression = { $_.'approximateLastSignInDateTime' | Out-String } },
     @{ Name = 'createdDateTime'; Expression = { $_.'createdDateTime' | Out-String } },
     @{ Name = 'deviceOwnership'; Expression = { $_.'deviceOwnership' } },
     @{ Name = 'displayName'; Expression = { $_.'displayName' } },
     @{ Name = 'enrollmentType'; Expression = { $_.'enrollmentType' } },
     @{ Name = 'isCompliant'; Expression = { $_.'isCompliant' } },
     @{ Name = 'managementType'; Expression = { $_.'managementType' } },
     @{ Name = 'manufacturer'; Expression = { $_.'manufacturer' } },
     @{ Name = 'model'; Expression = { $_.'model' } },
     @{ Name = 'operatingSystem'; Expression = { $_.'operatingSystem' } },
     @{ Name = 'onPremisesSyncEnabled'; Expression = { $(if ([string]::IsNullOrEmpty($_.'onPremisesSyncEnabled')) { $false }else { $true }) } },
     @{ Name = 'operatingSystemVersion'; Expression = { $_.'operatingSystemVersion' } },
     @{ Name = 'trustType'; Expression = { $_.'trustType' } },
     @{ Name = 'EPMID'; Expression = { $(Get-EPMID -deviceID $_.'deviceId' -EPMDevices $EPMDevices) } }
 	
- https://graph.microsoft.com/beta/users/$UserID/memberOf/$/microsoft.graph.group?`$select=id,displayName,mailEnabled,securityEnabled,groupTypes,onPremisesSyncEnabled,mail,isAssignableToRole`&$orderby=displayName asc" 
 Write-Host $URI
 $GraphRequest = New-GraphGetRequest -uri $URI -tenantid $TenantFilter -noPagination $true -verbose | select-object id,
 @{ Name = 'DisplayName'; Expression = { $_.displayName} },
 @{ Name = 'MailEnabled'; Expression = { $_.mailEnabled} },
 @{ Name = 'Mail'; Expression = { $_.mail} },
 @{ Name = 'SecurityGroup'; Expression = {$_.securityEnabled} },
 @{ Name = 'GroupTypes'; Expression = {  $_.groupTypes -join ','} },
 @{ Name = 'OnPremisesSync'; Expression = { $_.onPremisesSyncEnabled} },
 @{ Name = 'IsAssignableToRole'; Expression = { $_.isAssignableToRole} }
 
- https://outlook.office365.com/adminapi/beta/$($tenantfilter)/CasMailbox('$UserID')
- https://outlook.office365.com/adminapi/beta/$($tenantfilter)/Mailbox('$UserID') (scope exchangeonline)
 $UserID = $Request.Query.UserID
             $GraphRequest = New-ExoRequest -tenantid $TenantFilter -cmdlet "Get-InboxRule" -cmdParams @{mailbox = $UserID} | Select-Object
             @{ Name = 'DisplayName'; Expression = { $_.displayName} },
             @{ Name = 'Description'; Expression = { $_.Description} },
             @{ Name = 'Redirect To'; Expression = { $_.RedirectTo} },
             @{ Name = 'Copy To Folder'; Expression = { $_.CopyToFolder} },
             @{ Name = 'Move To Folder'; Expression = { $_.MoveToFolder} },
             @{ Name = 'Soft Delete Message'; Expression = { $_.SoftDeleteMessage} },
             @{ Name = 'Delete Message'; Expression = { $_.DeleteMessage} }
 			
- https://graph.microsoft.com/v1.0/users/$userId/photos/240x240/`$value
     $URI = "https://graph.microsoft.com/beta/auditLogs/signIns?`$filter=(userId eq '$UserID')&`$top=50&`$orderby=createdDateTime desc" 
     Write-Host $URI
     $GraphRequest = New-GraphGetRequest -uri $URI -tenantid $TenantFilter -noPagination $true -verbose | Select-Object @{ Name = 'Date'; Expression = { $(($_.createdDateTime | Out-String) -replace '\r\n') } },
     id,
     @{ Name = 'Application'; Expression = { $_.resourceDisplayName } },
     @{ Name = 'LoginStatus'; Expression = { $_.status.errorCode } },
     @{ Name = 'OverallLoginStatus'; Expression = { if (($_.conditionalAccessStatus -eq 'Success' -or 'Not Applied') -and $_.status.errorCode -eq 0) { 'Success' } else { 'Failed' } } },
     @{ Name = 'IPAddress'; Expression = { $_.ipAddress } },
     @{ Name = 'Town'; Expression = { $_.location.city } },
     @{ Name = 'State'; Expression = { $_.location.state } },
     @{ Name = 'ConditionalAccessStatus'; Expression = { $_.conditionalAccessStatus } },
     @{ Name = 'Country'; Expression = { $_.location.countryOrRegion } },
     @{ Name = 'Device'; Expression = { $_.deviceDetail.displayName } },
     @{ Name = 'DeviceCompliant'; Expression = { $_.deviceDetail.isCompliant } },
     @{ Name = 'OS'; Expression = { $_.deviceDetail.operatingSystem } },
     @{ Name = 'Browser'; Expression = { $_.deviceDetail.browser } },
     @{ Name = 'AppliedCAPs'; Expression = { ($_.appliedConditionalAccessPolicies | ForEach-Object { @{Result = $_.result; Name = $_.displayName } }) } },
     @{ Name = 'AdditionalDetails'; Expression = { $_.status.additionalDetails } },
     @{ Name = 'FailureReason'; Expression = { $_.status.failureReason } },
     @{ Name = 'FullDetails'; Expression = { $_ } }
 	
-  $PermsRequest = New-GraphGetRequest -uri "https://outlook.office365.com/adminapi/beta/$($tenantfilter)/Mailbox('$($Request.Query.UserID)')/MailboxPermission" -Tenantid $tenantfilter -scope ExchangeOnline 
-  $PermsRequest2 = New-GraphGetRequest -uri "https://outlook.office365.com/adminapi/beta/$($tenantfilter)/Recipient('$base64IdentityParam')?`$expand=RecipientPermission&isEncoded=true" -Tenantid $tenantfilter -scope ExchangeOnline 
-    $DKIM = (New-ExoRequest -tenantid $tenant -cmdlet "Get-DkimSigningConfig") | Where-Object -Property Enabled -EQ $false | ForEach-Object {
         (New-ExoRequest -tenantid $tenant -cmdlet "New-DkimSigningConfig" -cmdparams @{ KeySize = 2048; DomainName = $_.Identity; Enabled = $true } -useSystemMailbox $true)
 		
- https://graph.microsoft.com/beta/admin/reportSettings
  $DehydratedTenant = (New-ExoRequest -tenantid $Tenant -cmdlet "Get-OrganizationConfig").IsDehydrated
     if ($DehydratedTenant) {
         New-ExoRequest -tenantid $Tenant -cmdlet "Enable-OrganizationCustomization"
     }
     $AdminAuditLogParams = @{
         UnifiedAuditLogIngestionEnabled = $true
 		
  $CurrentState = (New-ExoRequest -tenantid $Tenant -cmdlet "Get-OrganizationConfig").AutoExpandingArchiveEnabled
     if (!$currentstate) {
         New-ExoRequest -tenantid $Tenant -cmdlet "Set-OrganizationConfig" -cmdParams @{AutoExpandingArchive = $true }
         Write-LogMessage -API "Standards" -tenant $tenant -message "Added Auto Expanding Archive." -sev Info
     }
 	
-   New-GraphPostRequest -tenantid $tenant -Uri "https://graph.microsoft.com/beta/admin/sharepoint/settings" -AsApp $true -Type PATCH -Body $body -ContentType "application/json"
-   https://graph.microsoft.com/beta/policies/authorizationPolicy/authorizationPolicy
     $GraphRequest = New-GraphgetRequest -uri "https://graph.microsoft.com/beta/users?`$filter=(signInActivity/lastSignInDateTime le $lookup)&`$select=id,UserPrincipalName,signInActivity,mail,userType,accountEnabled" -scope "https://graph.microsoft.com/.default" -tenantid $Tenant | Where-Object { $_.userType -EQ 'Guest' -and $_.AccountEnabled -EQ $true }
     foreach ($guest in $GraphRequest) {
-     New-GraphPostRequest -type Patch -tenantid $tenant -uri "https://graph.microsoft.com/beta/users/$($guest.id)" -body '{"accountEnabled":"false"}'
- https://graph.microsoft.com/beta/settings
- https://graph.microsoft.com/beta/admin/sharepoint/settings
- https://graph.microsoft.com/beta/policies/authorizationPolicy/authorizationPolicy
- https://graph.microsoft.com/beta/policies/authenticationmethodspolicy/authenticationMethodConfigurations/Fido2
- https://graph.microsoft.com/beta/policies/identitySecurityDefaultsEnforcementPolicy
- https://graph.microsoft.com/beta/policies/authorizationPolicy/authorizationPolicy
- https://graph.microsoft.com/beta/policies/permissionGrantPolicies/
- New-ExoRequest -tenantid $tenant -cmdlet "Set-HostedOutboundSpamFilterPolicy" -cmdparams @{ Identity = "Default"; NotifyOutboundSpam = $true; NotifyOutboundSpamRecipients = $Contacts.OutboundSpamContact } -useSystemMailbox $true
- https://graph.microsoft.com/beta/policies/authenticationMethodsPolicy/authenticationMethodConfigurations/microsoftAuthenticator
- https://graph.microsoft.com/beta/policies/identitySecurityDefaultsEnforcementPolicy
    $AdminAuditLogParams = @{
         SendFromAliasEnabled = $true
     }
-     New-ExoRequest -tenantid $Tenant -cmdlet "Set-OrganizationConfig" -cmdParams $AdminAuditLogParams
-     New-ExoRequest -tenantid $Tenant -cmdlet "Set-ExternalInOutlook" -cmdParams @{ Enabled = $status; }
- 	https://graph.microsoft.com/beta/policies/authenticationmethodspolicy/authenticationMethodConfigurations/TemporaryAccessPass
- https://graph.microsoft.com/beta/policies/deviceRegistrationPolicy
- https://graph.microsoft.com/beta/admin/sharepoint/settings