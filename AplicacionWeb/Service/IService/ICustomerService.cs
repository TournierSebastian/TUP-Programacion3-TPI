
using Modelos.Dto;
using Models.Dto;

namespace Service.IService
{
    public interface ICustomerService
    {

        List<DtoSellOrder> GetallOrder();

        DtoSellOrder GetOrderById(int id);
        string AddSellOrder(int id, DtoSellOrder orden);
        string DeleteOrderByid (int orderId);



        //test
        List<DtoProducts> GetAllProducts();
        
    }

}
