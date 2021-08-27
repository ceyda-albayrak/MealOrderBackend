using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts.EfService;
using Entities;

namespace Business.Abstracts.EfService
{
    public interface IOrderService : IService<Order>
    {
    }
}
