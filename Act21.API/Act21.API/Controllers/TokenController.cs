using Act21.API.Data;

using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

namespace Act21.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly UsersDbContext _userContext;
        /*private readonly ITokenService _tokenService;*/

        /*public TokenController(UsersDbContext userContext, ITokenService tokenService)*/
        public TokenController(UsersDbContext userContext)
        {
            this._userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
            /*this._tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));*/
        }

    }
}
