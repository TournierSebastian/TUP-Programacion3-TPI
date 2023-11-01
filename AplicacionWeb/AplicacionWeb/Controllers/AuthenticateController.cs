using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Modelos.Dto;
using Models.Dto;
using Service.IService;
using Service.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



namespace AplicacionWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    /// PROBANDO SI FUNCIONA EL AUTH DSP ORDENAR EN SUPERADMIN
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthService _authService;
        public IConfiguration _config;
        public AuthenticateController(IAuthService authService, IConfiguration config)
        {
            _authService = authService;
            _config = config;
        }


        [HttpPost]

        public IActionResult Login([FromBody] DtoCredentials dtoCredentials)
        {
            var login = _authService.ValidarUsuario(dtoCredentials.Email, dtoCredentials.Password);

            if (login == "Email Erroneo")
            {
                return NotFound("Email Erroneo");
            } else if (login == "Password error")
            {
                return Unauthorized();
            }
            if (login == "Logeado")
            {
                DtoUser user = _authService.GetUserByEmail(dtoCredentials.Email);

                var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));
                var signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);


                var claimsForToken = new List<Claim>();
                claimsForToken.Add(new Claim("sub", user.idUser.ToString()));
                claimsForToken.Add(new Claim("given_name", user.UserName));
                claimsForToken.Add(new Claim("role", user.Role));
                var jwtSecurityToken = new JwtSecurityToken(
                         _config["Authentication:Issuer"],
                         _config["Authentication:Audience"],
                         claimsForToken,
                         DateTime.UtcNow,
                         DateTime.UtcNow.AddHours(1),
                         signature);

                string tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                return Ok(tokenToReturn);
            }
            return BadRequest();
        }


        [HttpPost("createuser")]
        public IActionResult CreateUser([FromBody] DtoUser dto)
        {
            var user = new DtoUser()
            {
                Email = dto.Email,
                UserName = dto.UserName,
                Password = dto.Password,
                Role = "RoL"
            };
            int id = _authService.CreateUser(user);
            return Ok(id);
        }

    }
}
