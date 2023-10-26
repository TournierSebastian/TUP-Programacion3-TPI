using Microsoft.Extensions.Logging;
using Modelos.Dto;
using Models.Dto;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class AdminService
    {
        private readonly TiendaContext _TiendaContext;
            

        public AdminService(TiendaContext TiendaContext)
        {
            _TiendaContext = TiendaContext;
        }

       

        //public DtoProducts AddProducts(DtoProducts products)
        //{

        //}
    }
}
