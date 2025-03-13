using AXA_TEST_CASE.DTO;
using AXA_TEST_CASE.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AXA_TEST_CASE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthRepo _authRepo;
        private readonly TokenProvider _tokenProvider;

        public AuthController(AuthRepo authRepo, TokenProvider tokenProvider)
        {
            this._authRepo = authRepo;
            this._tokenProvider = tokenProvider;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequest req)
        {
            string hashdePassword = BCrypt.Net.BCrypt.HashPassword(req.Password);
            var result = await _authRepo.RegisterUser(req.Email, hashdePassword);

            if(result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest req)
        {
            AuthResponse response = new AuthResponse();
            
            var user  = await _authRepo.FindUserByEmail(req.Email);
            if(user == null)
                return BadRequest("User Not Found");

            var varifyPassword = BCrypt.Net.BCrypt.Verify(req.Password, user.Password);
            
            if(!varifyPassword)
                return BadRequest("Wrong Password ");


            var token = _tokenProvider.GenerateToken(user);
            response.AccessToken = token.AccessToken;

            return response;

        }

    }
}
