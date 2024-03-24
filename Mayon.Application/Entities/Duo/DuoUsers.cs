using System.Text.Json.Serialization;

namespace Mayon.Application.Entities.Duo;
public record DuoUsersResponse
{
    [JsonPropertyName("alias1")]
    public string? Alias1 { get; set; }

    [JsonPropertyName("alias2")]
    public string? Alias2 { get; set; }

    [JsonPropertyName("alias3")]
    public string? Alias3 { get; set; }

    [JsonPropertyName("alias4")]
    public string? Alias4 { get; set; }

    [JsonPropertyName("aliases")]
    public Aliases Aliases { get; set; }

    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("desktoptokens")]
    public string? DesktopTokens { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("firstname")]
    public string? FirstName { get; set; }

    [JsonPropertyName("groups")]
    public Group Groups { get; set; }

    [JsonPropertyName("is_enrolled")]
    public bool IsEnrolled { get; set; }

    [JsonPropertyName("last_directory_sync")]
    public int LastDirectorySync { get; set; }

    [JsonPropertyName("last_login")]
    public int LastLogin { get; set; }

    [JsonPropertyName("lastname")]
    public string? LastName { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("phones")]
    public Phone Phones { get; set; }

    [JsonPropertyName("realname")]
    public string? RealName { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("tokens")]
    public string? Tokens { get; set; }

    [JsonPropertyName("u2ftokens")]
    public string? U2fTokens { get; set; }

    [JsonPropertyName("user_id")]
    public string? UserId { get; set; }

    [JsonPropertyName("username")]
    public string? UserName { get; set; }

    [JsonPropertyName("webauthncredentials")]
    public string? WebAuthnCredentials { get; set; }
}

public record Aliases();

public record Group
{
    [JsonPropertyName("desc")]
    public string? Desc { get; set; }

    [JsonPropertyName("group_id")]
    public string? GroupId { get; set; }

    [JsonPropertyName("mobile_otp_en")]
    public bool MobileOtpEn { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("push_enabled")]
    public bool PushEnabled { get; set; }

    [JsonPropertyName("sms_enabled")]
    public bool SmsEnabled { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("voice_enabled")]
    public bool VoiceEnabled { get; set; }
}

public record Phone
{
    [JsonPropertyName("activated")]
    public bool Activated { get; set; }

    [JsonPropertyName("capabilities")]
    public string? Capabilities { get; set; }

    [JsonPropertyName("extension")]
    public string? Extension { get; set; }

    [JsonPropertyName("last_seen")]
    public string? LastSeen { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("number")]
    public string? Number { get; set; }

    [JsonPropertyName("phone_id")]
    public string? PhoneId { get; set; }

    [JsonPropertyName("platform")]
    public string? Platform { get; set; }

    [JsonPropertyName("postdelay")]
    public string? PostDelay { get; set; }

    [JsonPropertyName("predelay")]
    public string? PreDelay { get; set; }

    [JsonPropertyName("sms_passcodes_sent")]
    public bool SmsPasscodesSent { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}