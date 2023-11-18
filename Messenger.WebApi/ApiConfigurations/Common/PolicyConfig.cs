using MessengerX.Domain.Shared.Constants.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace MessengerX.WebApi.ApiConfigurations.Common;

public static class PolicyConfigExtension
{
    private static readonly string[] AllowOrigins =
    {
        "http://localhost:3000",
        "https://localhost:3000"
    };

    public static void PolicyConfig(this AuthorizationOptions authorizationOptions)
    {
        authorizationOptions.AddPolicy(AuthPolicy.OnlyUser, policy => policy.RequireRole("User"));
        authorizationOptions.AddPolicy(AuthPolicy.OnlyAdmin, policy => policy.RequireRole("Admin"));
        authorizationOptions.AddPolicy(AuthPolicy.FullAccess, policy => policy.Build());
    }

    public static void CorsConfig(this CorsOptions corsOptions)
    {
        corsOptions.AddPolicy(
            CorsPolicyName.Default,
            policy =>
                policy
                    .WithOrigins(AllowOrigins)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
        );
    }
}
