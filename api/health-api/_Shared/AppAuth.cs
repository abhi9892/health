using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using health_api._Shared.dbc.auth;
using Newtonsoft.Json;

public class AppAuth
{
    readonly IConfiguration _configuration;
    readonly AuthContext _authContext;

    public AppAuth(IConfiguration configuration) => _configuration = configuration ?? throw new ArgumentNullException(nameof(_configuration));

    public AppAuth(IConfiguration configuration, AuthContext authContext) : this(configuration)
    {
        _authContext = authContext;
    }

    public bool Authenticate(LoginRequestModel loginInfo)
    {
        var rs = _authContext.Users
            .Where(u => u.Email == loginInfo.Email && u.Password == loginInfo.Password && u.IsLockedOut == false)
            .FirstOrDefault();

        if (rs is null)
            return false;

        return true;
    }

    public bool AuthenticateQuickLogin(LoginRequestModel loginInfo)
    {
        var rs = _authContext.Users
            .Where(u => u.Email == loginInfo.Email && u.IsLockedOut == false)
            .FirstOrDefault();

        if (rs is null)
            return false;

        return true;
    }

    public string GenerateToken(string email)
    {

        var rs = _authContext.Users.Where(e => e.Email == email).OrderBy(i => i.Id).ToList();
        var userInfo = rs.FirstOrDefault();

        var userRoles = _authContext.UserRoles.Where(e => e.UserId == userInfo.Id).First();
        var roles = _authContext.Roles.Where(e => e.Id == userRoles.RoleId).First();


        var issuer = _configuration["JWT:Issuer"];
        var audience = _configuration["JWT:Audience"];
        var key = System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"] ?? throw new ArgumentNullException(nameof(_configuration)));

        var ci = new ClaimsIdentity(new[]
            {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim("fullname",userInfo.FullName??""),
                new Claim("userRoles", JsonConvert.SerializeObject(new string[] { roles.Name }))
            });
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = ci,
            Expires = DateTime.UtcNow.AddMinutes(5),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)

        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwt = tokenHandler.WriteToken(token);

        return jwt;
    }

    public void GetJwtBearerOptions(JwtBearerOptions jwtBearerOptions)
    {
        string signingKey = _configuration["Jwt:SigningKey"] ?? "";

        jwtBearerOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidIssuer = _configuration["Jwt:Issuer"],
            ValidAudience = _configuration["Jwt:ValidAudience"],

            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(signingKey)),
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
        };
    }

    internal void GetAuthorizationOptions(AuthorizationOptions options)
    {
        options.FallbackPolicy = new Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build();
    }
}


public record LoginRequestModel
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}

