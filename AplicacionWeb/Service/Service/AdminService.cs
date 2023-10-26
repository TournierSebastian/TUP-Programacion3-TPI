using Microsoft.Extensions.Logging;
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
    public class AdminService : IAdminService
    {
        private readonly TiendaContext _TiendaContext;
            

        public AdminService(TiendaContext TiendaContext)
        {
            _TiendaContext = TiendaContext;
        }

        

        public DtoProducts AddProducts(DtoProducts products)
        {
            
            if (products == null || products.Name == "" || products.Descripcion == "" || products.Price == 0)
            {
                return null;
            }
            _TiendaContext.DtoProducts.Add(products);
            _TiendaContext.SaveChanges();
            return products;
        }
        public List <DtoProducts> GetAllProducts()
        {
             var Response = _TiendaContext.DtoProducts.ToList();
            return Response;
        }
        public  DtoProducts GetProductsById(int id)
        {
            var Response = _TiendaContext.DtoProducts.FirstOrDefault(x => x.idProducts == id);
            return Response;
        }

        public string DeleteProductByID(int id)
        {
            var products = _TiendaContext.DtoProducts.FirstOrDefault(x => x.idProducts == id);
            if(products == null) 
            {
                return ("Product Not Found");            
            }
            _TiendaContext.Remove(products);
            _TiendaContext.SaveChanges();
            return ("Product Delete");

        }
    }
    
}
