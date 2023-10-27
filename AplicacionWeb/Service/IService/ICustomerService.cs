
using Modelos.Dto;

namespace Service.IService
{
    public interface ICustomerService
    {

        List<DtoSellOrder> GetallOrder();

        DtoSellOrder GetOrderById(int id);
        DtoSellOrder AddSellOrder(DtoSellOrder orden);
        string DeleteOrderByid (int orderId);

    }

}
