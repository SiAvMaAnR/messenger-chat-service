using MessengerX.Domain.Exceptions.ApiExceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MessengerX.Infrastructure.AuthOptions;

public static class TokenOptions
{
    public static void Config(this JwtBearerOptions options, ConfigurationManager? configuration)
    {
        if (configuration == null)
            throw new BadRequestException("Incorrect config");

        string secretKey =
            configuration.GetSection("Authorization:SecretKey").Value
            ?? throw new BadRequestException("Incorrect secretKey");

        // options.RequireHttpsMetadata = true;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration.GetSection("Authorization:Issuer").Value,
            ValidAudience = configuration.GetSection("Authorization:Audience").Value,
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
                var accessToken = context.Request.Query["access_token"];

                var path = context.HttpContext.Request.Path;
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

        var expires = DateTime.Now.AddMinutes(double.Parse(tokenParams["lifeTime"]));

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
