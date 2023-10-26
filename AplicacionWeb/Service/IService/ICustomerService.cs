using Microsoft.AspNetCore.Mvc;
using Modelos.Dto;
using Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface ICustomerService
    {

        List<DtoSellOrder> GetallOrder();

        DtoSellOrder GetOrderById(int id);
        DtoSellOrder AddSellOrder(DtoSellOrder orden);
        string DeleteOrderByid (int orderId);

    }

}
