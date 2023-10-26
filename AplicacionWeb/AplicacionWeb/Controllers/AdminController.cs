using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using Service.IService;

namespace AplicacionWeb.Controllers
{
    [Route("api/Admin")]
    [ApiController]
    public class AdminController : ControllerBase

    {
        private readonly IAdminService _AdminService;
        private readonly ILogger _logger;

        public AdminController(IAdminService adminService,  ILogger<AdminController> logger)
        {
            _logger = logger;
            _AdminService = adminService;
        }

        [HttpPost("AddProduct")]
        public ActionResult<DtoProducts> AddProducts([FromBody]DtoProducts products)
        {
            _AdminService.AddProducts(products);
            return Ok("se anadio");
        }
    }
}
