using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using Models.Models;
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


        [HttpGet("GetAllProducts")]
        public ActionResult <List<DtoProducts>> GetAllProducts()
        {
            try
            {
                var Response = _AdminService.GetAllProducts();

                if (Response == null)
                {
                    return NotFound("Products Not Found");
                }
                return Ok(Response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in GetAllProduct: {ex}");
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("GetProductsByid/{id}")]
        public ActionResult<DtoProducts> GetProductsById(int id)
        {
            try
            {
                var Response = _AdminService.GetProductsById(id);

                if (Response == null)
                {
                    return NotFound("Product Not Found");
                }
                return Ok(Response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in GetProductById: {ex}");
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPost("AddProduct")]
        public ActionResult<DtoProducts> AddProducts([FromBody] DtoProducts products)
        {

            try
            {
                var Response = _AdminService.AddProducts(products);
                if (Response == null)
                {
                    return NotFound("incomplete data");
                }
                return Ok($"added product");

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in AddProduct: {ex}");
                return BadRequest($"{ex.Message}");
            }
        }
        [HttpDelete("DeleteProductsById / {id}")]
        public ActionResult<string> DeleteProductById(int id)
        {
            try
            {
                var Response = _AdminService.DeleteProductByID(id);

                if (Response == "Product Not Found")
                {
                    return NotFound("Product Not Found");
                }
                return Ok(Response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in GetProductById: {ex}");
                return BadRequest($"{ex.Message}");
            }

        }
        [HttpPut("ModifyProductById / {id}")]
        public ActionResult <string> ModifyProductById(int id, Products product)
        {


            try
            {
                var Response = _AdminService.ModifyProductById(id, product);

                if (Response != "Modified Product")
                {
                    return NotFound("Unmodified product");
                }
                return Ok(Response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in ModifyProductById: {ex}");
                return BadRequest($"{ex.Message}");
            }
            
           
        }

    }
}
