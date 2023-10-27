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

        public SuperAdminController(ISuperAdminService superAdminService, ILogger<SuperAdminController> logger)
        {
            _SuperAdminService = superAdminService;
            _logger = logger;
        }

        [HttpGet("GetAllUser")]

        public ActionResult<List<DtoUser>> GetAllUser()
        {
            try
            {
                var response = _SuperAdminService.GetAllUser();
                return response;

            }catch (Exception ex)
            {
                _logger.LogError($"An error occurred in GetAllUser: {ex}");
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPost("AddUser")]
        public ActionResult <DtoUser> AddUser(DtoUser user)
        {

            try {
               var response = _SuperAdminService.AddUser(user);
                if(response == null)
                {
                    return Ok("Incomplete Data or existing user ");
                }
               
                return Ok("Added User");
            }
            catch(Exception ex)
            {
                _logger.LogError($"An error occurred in AddUser: {ex}");
                return BadRequest($"{ex.Message}");
            }
           
        }

        [HttpDelete("DeleteUserByid/{id}")]

        public ActionResult<string> DeleteUserByid(int id){ 
        
           
            try
            {
                var response = _SuperAdminService.DeleteUserByid(id);
                if (response == "Delete User")
                {
                    return response;

                }

                return NotFound("User Not Found");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in DeleteUserByid: {ex}");
                return BadRequest($"{ex.Message}");
            }

        }
    }
}
