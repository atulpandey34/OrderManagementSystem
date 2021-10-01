using DataAccessLayer.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services.Interface
{
    public interface IOrderService
    {
        bool AddOrder(Order order);
        bool UpdateOrder(Order order);
        IEnumerable<Order> GetAllOrderByUser(int userid);
    }
}
