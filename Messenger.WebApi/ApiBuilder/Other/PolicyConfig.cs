using MessengerX.Domain.Shared.Constants.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace MessengerX.WebApi.ApiBuilder.Other;

public static class PolicyConfigExtension
{
    private static readonly string[] s_allowOrigins =
    [
        "http://localhost:3000",
        "https://localhost:3000"
    ];

    public static void PolicyConfig(this AuthorizationOptions authorizationOptions)
    {
        authorizationOptions.AddPolicy(AuthPolicy.OnlyUser, policy => policy.RequireRole("User"));
        authorizationOptions.AddPolicy(AuthPolicy.OnlyAdmin, policy => policy.RequireRole("Admin"));
        authorizationOptions.AddPolicy(
            AuthPolicy.FullAccess,
            policy => policy.RequireAssertion(context => true)
        );
    }

    public static void CorsConfig(this CorsOptions corsOptions)
    {
        corsOptions.AddPolicy(
            CorsPolicyName.Default,
            policy =>
                policy
                    .WithOrigins(s_allowOrigins)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
        );
    }
}
