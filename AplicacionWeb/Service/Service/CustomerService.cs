
using Modelos.Dto;
using Models.Dto;
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


        public string AddSellOrder(int id , DtoSellOrder orden)
        {
            var product = _TiendaContext.DtoProducts.FirstOrDefault(x => x.idProducts == id);
            if (orden.PayMethod == "")
            {
                return "error"; 
            }
            orden.PayMethod = orden.PayMethod;
            orden.TotalValue = product.Price;
            _TiendaContext.Add(orden);
            _TiendaContext.SaveChanges();

            return "se agrego";
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



        public List<DtoProducts> GetAllProducts()
        {
            var products = _TiendaContext.DtoProducts.ToList();
            return products;
        }
    }
}
