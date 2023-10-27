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
    public class SuperAdminService : ISuperAdminService
    {
        private readonly TiendaContext _TiendaContext;

        public SuperAdminService(TiendaContext TiendaContext)
        {
            _TiendaContext = TiendaContext;
        }

        public DtoUser AddUser(DtoUser user)
        {
             

            //if(user.Email.Contains("@") && user.Email.EndsWith(".com"))
           // {
                _TiendaContext.DtoUsers.Add(user);
            _TiendaContext.SaveChanges();
                return (user);
           // }
            //return null;
        }

    }
}
