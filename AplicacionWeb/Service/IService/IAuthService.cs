using Models.Dto;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IAuthService
    {
        string ValidarUsuario(string username, string password);
        public DtoUser? GetUserByEmail(string username);
        public int CreateUser(DtoUser user);
    }
}
