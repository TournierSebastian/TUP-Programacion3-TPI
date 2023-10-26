using Microsoft.AspNetCore.Mvc;
using Modelos.Dto;
using Models.Dto;
using Models.Models;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class CustomerService : ICustomerService
    {

        private readonly TiendaContext _context;
        public CustomerService(TiendaContext context) 
        { 
            _context = context; 
        }


        public IActionResult AddSellOrder(DtoSellOrder orden)
        {
           

            _context.DtoSellOrders.Add(orden);
            _context.SaveChangesAsync();

            return new OkObjectResult("Orden de venta creada exitosamente.");
        }
       
        public string DeleteOrderByid (int orderid)
        {
            var order = _context.DtoSellOrders.FirstOrDefault(x =>x.idOrder == orderid);
             string response = string.Empty;

            if (order == null)
            {
                return "Sell Order not found";
            }
            else
            {
                _context.Remove(order);
                _context.SaveChangesAsync();
                return "Sell Order deleted";
               
            }
            
        }


        public List<DtoSellOrder> GetallOrder()
        {

            var order = _context.DtoSellOrders.ToList();
            return order;
            
        }


        public DtoSellOrder GetOrderById(int id)
        {
            var order = _context.DtoSellOrders.FirstOrDefault(x =>x.idOrder == id);

            return order; 
        }
    }
}
