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
            _TiendaContext.DtoProducts.Add(products);
            _TiendaContext.SaveChanges();
            return products;
        }
    }
}
