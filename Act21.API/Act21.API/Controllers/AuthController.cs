using Act21.API.Models;
using Act21.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace JwtAuthentication.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UsersDbContext _userContext;
        /*private readonly ITokenService _tokenService;*/

        public AuthController(UsersDbContext userContext)
        {
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
            /*_tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));*/
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            if (loginModel is null)
            {
                return BadRequest("Invalid client request");
            }
            var user = _userContext.LoginInfos.FirstOrDefault(u =>
                (u.Email == loginModel.Email) && (u.Password == loginModel.Password));

            if (user==null)
            {
                return Unauthorized();
            }
            
            
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim (ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)


            };

            
            /*_userContext.SaveChanges();*/
           
            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:7062",
                audience: "https://localhost:7062",
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return Ok(new AuthenticatedResponse { Token = tokenString });


            /*return Unauthorized();*/
        }
    }
}

/*using Act21.API.Data;
using Act21.API.Models;
using Act21.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Act21.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly UserContext _userContext;
        private readonly ITokenService _tokenService;
        public AuthController(UserContext userContext, ITokenService tokenService)
        {
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            if (loginModel is null)
            {
                return BadRequest("Invalid client request");
            }
            var user = _userContext.LoginModels.FirstOrDefault(u =>
                (u.Email == loginModel.Email) && (u.Password == loginModel.Password));
            if (user is null)
                return Unauthorized();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, loginModel.Email),
            new Claim(ClaimTypes.Role, "Manager")
        };
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            _userContext.SaveChanges();
            return Ok(new AuthenticatedResponse
            {
                Token = accessToken,
                RefreshToken = refreshToken
            });
        }
    }
}*/
