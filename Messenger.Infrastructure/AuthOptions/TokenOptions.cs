using MessengerX.Domain.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MessengerX.Infrastructure.AuthOptions;

public static class TokenExtension
{
    // public static void Config(this JwtBearerOptions options, ConfigurationManager? config)
    // {
    //     if (config == null) throw new BadRequestException("Incorrect config");

    //     string secretKey = config.GetSection("Authorization:SecretKey").Value
    //         ?? throw new BadRequestException("Incorrect secretKey");

    //     // options.RequireHttpsMetadata = true;
    //     options.SaveToken = true;
    //     options.TokenValidationParameters = new TokenValidationParameters
    //     {
    //         ValidateIssuer = true,
    //         ValidateAudience = true,
    //         ValidateLifetime = true,
    //         ValidateIssuerSigningKey = true,

    //         ValidIssuer = config.GetSection("Authorization:Issuer").Value,
    //         ValidAudience = config.GetSection("Authorization:Audience").Value,
    //         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
    //         LifetimeValidator = (DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters) =>
    //              (expires != null) ? DateTime.UtcNow < expires : false
    //     };

    //     options.Events = new JwtBearerEvents
    //     {
    //         OnMessageReceived = context =>
    //         {
    //             var accessToken = context.Request.Query["access_token"];

    //             var path = context.HttpContext.Request.Path;
    //             if (!string.IsNullOrEmpty(accessToken))
    //             {
    //                 context.Token = accessToken;
    //             }
    //             return Task.CompletedTask;
    //         }
    //     };
    // }


    // public static string CreateToken(List<Claim> claims, Dictionary<string, string> tokenParams)
    // {
    //     try
    //     {
    //         ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimTypes.Email, ClaimTypes.Role);

    //         var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenParams["secretKey"]));

    //         var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

    //         var token = new JwtSecurityToken(
    //             audience: tokenParams["audience"],
    //             issuer: tokenParams["issuer"],
    //             claims: claims,
    //             expires: DateTime.Now.AddMinutes(double.Parse(tokenParams["lifeTime"])),
    //             signingCredentials: creds);

    //         return new JwtSecurityTokenHandler().WriteToken(token);
    //     }
    //     catch (Exception)
    //     {
    //         return "";
    //     }
    // }
}
