using Microsoft.AspNetCore.Mvc;
using Modelos.Dto;
using Models.Dto;
using Service.IService;
using Service.Service;


namespace AplicacionWeb.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _ICustomerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService ICustomerService, ILogger<CustomerController> looger)
        {
            _ICustomerService = ICustomerService;
            _logger = looger;
        }

        [HttpGet("GetAllProducts")]
        public ActionResult<List<DtoProducts>> GetAllProducts()
        {
            try
            {
                var Response = _ICustomerService.GetAllProducts();

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


        [HttpGet("GetAllOrders")]
        public ActionResult<List<DtoSellOrder>> GetallOrder()
        {
            try
            {
                var response = _ICustomerService.GetallOrder();
                if (response == null || response.Count == 0)
                {

                    return NotFound("Sell orders not found");
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in GetallOrder: {ex}");
                return BadRequest($"{ex.Message}");
            }


        }
        [HttpGet("GetOrderByid/{id}")]
        public ActionResult<DtoSellOrder> GetOrderById(int id)
        {
            try
            {
                var response = _ICustomerService.GetOrderById(id);
                if (response == null)
                {
                    return NotFound("Sell order not found");
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in GetOrderById: {ex}");
                return BadRequest($"{ex.Message}");
            }

        }

    [HttpPost("AddSellOrder/ {id}")]
        public ActionResult<string> AddSellOrder([FromBody] DtoSellOrder orden, int id)
        {
            try
            {
                var response = _ICustomerService.AddSellOrder(id, orden);
                if (response == "error")
                {
                    return BadRequest("Incomplete Data");
                }
         
                return Ok("Added Product");
            } catch (Exception ex)
            {
                _logger.LogError($"An error occurred in AddSellOrder: {ex}");
                return BadRequest($"{ex.Message}");
            }

        }
        [HttpDelete("DeleteOrder{orderid}")]

        public ActionResult<string> DeleteOrderByid(int orderid)
        {
            var response = _ICustomerService.DeleteOrderByid(orderid);

            try
            {
                if (response == "Sell Order deleted")
                {
                    return Ok("Sell Order deleted");
                }
                return NotFound("Sell Order not found");

            }catch (Exception ex)
            {
                _logger.LogError($"An error occurred in DeleteOrderByid: {ex}");
                return BadRequest($"{ex.Message}");
            }
           
        }


      
    }
}

