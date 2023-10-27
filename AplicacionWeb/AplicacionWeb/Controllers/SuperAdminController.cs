using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using Service.IService;

namespace AplicacionWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperAdminController : ControllerBase
    {
        private readonly ISuperAdminService _SuperAdminService;
        private readonly ILogger _logger;

        public SuperAdminController(ISuperAdminService superAdminService, ILogger logger)
        {
            _SuperAdminService = superAdminService;
            _logger = logger;
        }

        [HttpPost("AddUser")]
        public ActionResult <DtoUser> AddUser(DtoUser user)
        {
            _SuperAdminService.AddUser(user);
            return Ok("funciona papu");
        }
    }
}
