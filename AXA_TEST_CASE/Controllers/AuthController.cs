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
        private readonly DataAccess dataAccess;

        public AuthController(DataAccess _dataAccess)
        {
            this.dataAccess = _dataAccess;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserAccount req)
        {
            string hashdePassword = BCrypt.Net.BCrypt.HashPassword(req.Password);
            var result = await dataAccess.RegisterUser(req.Email, hashdePassword);

            if(result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
         
    }
}
