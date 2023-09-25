using ExampleApi.Application.Common.Interfaces.Authentication;
using ExampleApi.Application.Common.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExampleApi.Infrastructure.Authentication;

public class JWTTokenGenerator : IJWTTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public JWTTokenGenerator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public string GenerateToken(Guid userId, string firstName, string lastName)
    {

        //TODO: this should come from user secrets

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This-Is-A-Super-Secret-Password-Key")),
            SecurityAlgorithms.HmacSha256
            );

        var claims = new[]
        {
            new Claim (JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim (JwtRegisteredClaimNames.GivenName, firstName),
            new Claim (JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())   
        };

        var securityToken = new JwtSecurityToken(
            issuer: "Grant-Shaw",
            expires: _dateTimeProvider.UtcNow.AddMinutes(60),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
