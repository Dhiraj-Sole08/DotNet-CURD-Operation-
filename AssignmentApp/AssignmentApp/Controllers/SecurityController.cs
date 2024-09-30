using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AssignmentApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // Replace this with actual user validation logic
            if (login.Username == "admin" && login.Password == "password")
            {
                var token = GenerateJwtToken(login.Username);
                return Ok(new { token });
            }
            return Unauthorized();
        }

        private string GenerateJwtToken(string username)
        {
            var algo = SecurityAlgorithms.HmacSha256;
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,username),
                new Claim(JwtRegisteredClaimNames.Sub,username),
                new Claim(JwtRegisteredClaimNames.Email,""),
                new Claim("IsAdmin","True"),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("victoriasecret@123421victoriasecret@123421"));
            var creadentials=new SigningCredentials(securitykey,algo);
            var token = new JwtSecurityToken("Questpond", "BrowserClients", claims, expires: DateTime.Now.AddHours(1), signingCredentials: creadentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
