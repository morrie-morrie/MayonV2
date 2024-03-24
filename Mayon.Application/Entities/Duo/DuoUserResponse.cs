using System.Text.Json.Serialization;

namespace Mayon.Application.Entities.Duo;
public record DuoUserResponse
{
    public record Aliases
    { }

    public record Group
    {
        [JsonPropertyName("desc")]
        public string Desc { get; set; }

        [JsonPropertyName("group_id")]
        public string GroupId { get; set; }

        [JsonPropertyName("mobile_otp_enabled")]
        public bool? MobileOtpEnabled { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("push_enabled")]
        public bool? PushEnabled { get; set; }

        [JsonPropertyName("sms_enabled")]
        public bool? SmsEnabled { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("voice_enabled")]
        public bool? VoiceEnabled { get; set; }
    }

    public record Metadata
    {
        [JsonPropertyName("total_objects")]
        public int? TotalObjects { get; set; }
    }

    public record Phone
    {
        [JsonPropertyName("activated")]
        public bool? Activated { get; set; }

        [JsonPropertyName("capabilities")]
        public List<string> Capabilities { get; set; }

        [JsonPropertyName("extension")]
        public string Extension { get; set; }

        [JsonPropertyName("last_seen")]
        public string LastSeen { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("phone_id")]
        public string PhoneId { get; set; }

        [JsonPropertyName("platform")]
        public string Platform { get; set; }

        [JsonPropertyName("postdelay")]
        public string PostDelay { get; set; }

        [JsonPropertyName("predelay")]
        public string PreDelay { get; set; }

        [JsonPropertyName("sms_passcodes_sent")]
        public bool? SmsPasscodesSent { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public record Response
    {
        [JsonPropertyName("alias1")]
        public object Alias1 { get; set; }

        [JsonPropertyName("alias2")]
        public object Alias2 { get; set; }

        [JsonPropertyName("alias3")]
        public object Alias3 { get; set; }

        [JsonPropertyName("alias4")]
        public object Alias4 { get; set; }

        [JsonPropertyName("aliases")]
        public Aliases Aliases { get; set; }

        [JsonPropertyName("created")]
        public double? Created { get; set; }

        [JsonPropertyName("desktoptokens")]
        public List<object> DesktopTokens { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }

        [JsonPropertyName("groups")]
        public List<Group> Groups { get; set; }

        [JsonPropertyName("is_enrolled")]
        public bool? IsEnrolled { get; set; }

        [JsonPropertyName("last_directory_sync")]
        public double? LastDirectorySync { get; set; }

        [JsonPropertyName("last_login")]
        public double? LastLogin { get; set; }

        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        [JsonPropertyName("Phones")]
        public List<Phone> Phones { get; set; }

        [JsonPropertyName("realname")]
        public string RealName { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("tokens")]
        public List<Tokens> Tokens { get; set; }

        [JsonPropertyName("u2ftokens")]
        public List<U2Tokens> U2fTokens { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [JsonPropertyName("webauthncredentials")]
        public List<WebauthnCredentials> WebAuthnCredentials { get; set; }
    }

    public record WebauthnCredentials
    {
        [JsonPropertyName("serial")]
        public string Serial { get; set; }

        [JsonPropertyName("token_id")]
        public string TokenId { get; set; }

        [JsonPropertyName("totp_step")]
        public string TotpStep { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public record U2Tokens
    {
        [JsonPropertyName("serial")]
        public string Serial { get; set; }

        [JsonPropertyName("token_id")]
        public string TokenId { get; set; }

        [JsonPropertyName("totp_step")]
        public string TotpStep { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public record Tokens
    {
        [JsonPropertyName("serial")]
        public string Serial { get; set; }

        [JsonPropertyName("token_id")]
        public string TokenId { get; set; }

        [JsonPropertyName("totp_step")]
        public string TotpStep { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public record Root
    {
        [JsonPropertyName("Metadata")]
        public Metadata Metadata { get; set; }

        [JsonPropertyName("Response")]
        public List<Response> Response { get; set; }

        [JsonPropertyName("stat")]
        public string Stat { get; set; }
    }
}