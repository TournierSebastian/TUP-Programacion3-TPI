
using Modelos.Dto;

using Models.Models;
using Service.IService;


namespace Service.Service
{
    public class CustomerService : ICustomerService
    {

        private readonly TiendaContext _TiendaContext;
        public CustomerService(TiendaContext context) 
        {
            _TiendaContext = context; 
        }


        public DtoSellOrder AddSellOrder(DtoSellOrder orden)
        {

            if (orden.PayMethod == "" || orden.TotalValue == 0)
            {

                return null; 
            }


            _TiendaContext.DtoSellOrders.Add(orden);
            _TiendaContext.SaveChanges();

            return orden;
        }
       
        public string DeleteOrderByid (int orderid)
        {
            var order = _TiendaContext.DtoSellOrders.FirstOrDefault(x =>x.idOrder == orderid);
             string response = string.Empty;

            if (order == null)
            {
                return "Sell Order not found";
            }
            else
            {
                _TiendaContext.Remove(order);
                _TiendaContext.SaveChanges();
                return "Sell Order deleted";
               
            }
            
        }
        public List<DtoSellOrder> GetallOrder()
        {

            var order = _TiendaContext.DtoSellOrders.ToList();
            return order;
            
        }


        public DtoSellOrder GetOrderById(int id)
        {
            var order = _TiendaContext.DtoSellOrders.FirstOrDefault(x =>x.idOrder == id);

            return order; 
        }
    }
}
