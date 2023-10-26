using Modelos.Dto;
using Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IAdminService
    {

        DtoProducts AddProducts(DtoProducts products); 
        List <DtoProducts> GetAllProducts();
        DtoProducts GetProductsById(int id);
        string DeleteProductByID(int id);
    }
}
