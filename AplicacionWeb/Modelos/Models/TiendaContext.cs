using Microsoft.EntityFrameworkCore;
using Modelos.Dto;
using Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class TiendaContext: DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options)
            : base(options)
        { 

        }


        public DbSet<DtoUser> DtoUsers { get; set; }

        public DbSet<DtoProducts> DtoProducts { get; set; }
        
        public DbSet<DtoSellOrder>DtoSellOrders { get; set; }

            
    }
}
