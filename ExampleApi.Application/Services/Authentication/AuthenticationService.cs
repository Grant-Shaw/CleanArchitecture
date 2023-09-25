using ExampleApi.Application.Common.Interfaces.Authentication;

namespace ExampleApi.Application.Services.Authentication;


public class AuthenticationService : IAuthenticationService
{

    private readonly IJWTTokenGenerator _jwtTokenGenerator;

    public AuthenticationService (IJWTTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName", email, "token");
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //check if user already exists

        //create user (generate unique ID)

        //create token
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

        return new AuthenticationResult(Guid.NewGuid(), firstName, lastName, email, token);
    }
}
