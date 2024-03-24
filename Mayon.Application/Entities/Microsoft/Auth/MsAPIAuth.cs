namespace Mayon.Application.Entities.Microsoft.Auth;

public record MSPartnerToken(

    string? token_type,
    string? expires_in,
    string? ext_expires_in,
    string? access_token
);

public record MSCustomerToken(
    string? token_type,
    string? expires_in,
    string? ext_expires_in,
    string? access_token
);

public record MSExchangeToken(
 string token_type,
 string scope,
 string expires_in,
 string ext_expires_in,
 string expires_on,
 string not_before,
 string resource,
 string access_token,
 string refresh_token
    );