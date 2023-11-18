using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MessengerX.Domain.Exceptions.ApiExceptions;
using MessengerX.Domain.Shared.Environment;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MessengerX.Infrastructure.AuthOptions;

public static class TokenOptions
{
    public static void Config(this JwtBearerOptions options, IConfiguration configuration)
    {
        CommonSettings commonSettings = new();
        AuthSettings authSettings = new();

        configuration.GetSection(CommonSettings.Path).Bind(commonSettings);
        configuration.GetSection(AuthSettings.Path).Bind(authSettings);

        if (configuration == null)
            throw new BadRequestException("Incorrect config");

        string secretKey = commonSettings.SecretKey;

        string? issuer = authSettings.Issuer;
        string? audience = authSettings.Audience;

        // options.RequireHttpsMetadata = true;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            LifetimeValidator = (
                DateTime? notBefore,
                DateTime? expires,
                SecurityToken securityToken,
                TokenValidationParameters validationParameters
            ) => (expires != null) ? DateTime.UtcNow < expires : false
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                Microsoft.Extensions.Primitives.StringValues accessToken = context.Request.Query["access_token"];

                Microsoft.AspNetCore.Http.PathString path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken))
                {
                    context.Token = accessToken;
                }
                return Task.CompletedTask;
            }
        };
    }

    public static string CreateToken(List<Claim> claims, Dictionary<string, string> tokenParams)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenParams["secretKey"]));

        DateTime expires = DateTime.Now.AddMinutes(double.Parse(tokenParams["lifeTime"]));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            audience: tokenParams["audience"],
            issuer: tokenParams["issuer"],
            claims: claims,
            expires: expires,
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
