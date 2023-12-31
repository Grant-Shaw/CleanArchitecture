﻿using ExampleApi.Application.Common.Interfaces.Authentication;
using ExampleApi.Application.Common.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExampleApi.Infrastructure.Authentication;

public class JWTTokenGenerator : IJWTTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JWTOptions _options;

    public JWTTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JWTOptions> options)
    {
        _dateTimeProvider = dateTimeProvider;
        _options = options.Value;
    }

    public string GenerateToken(Guid userId, string firstName, string lastName)
    {

        //TODO: this should come from user secrets

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret!)),
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
            issuer: _options.Issuer,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_options.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
