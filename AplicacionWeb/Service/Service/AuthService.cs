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
    public class AuthService: IAuthService
    {
        private readonly TiendaContext _context;

        public AuthService(TiendaContext context)
        {
            _context = context;
        }

        public DtoUser? GetUserByEmail(string email)
        {
            return _context.DtoUsers.SingleOrDefault(u => u.Email == email);
        }
    

        public string ValidarUsuario(string email, string password)
        {
        
            DtoUser? userForLogin = _context.DtoUsers.SingleOrDefault(x => x.Email == email);
            if (userForLogin != null)           
            {
                if (userForLogin.Password == password)
                {

                    return "Logeado";
                }
                else
                {
                    return "Password error";
                }
            }
            else
            {
                return "Email Erroneo";
            }
        }
        public int CreateUser(DtoUser user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.idUser;
        }

    }
}
