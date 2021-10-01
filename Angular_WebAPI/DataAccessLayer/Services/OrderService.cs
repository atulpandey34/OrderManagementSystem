using DataAccessLayer.DB;
using DataAccessLayer.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly OMSDBContext _dbContext;
        public OrderService(OMSDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public bool AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateOrder(Order order)
        {
            var entity = _dbContext.Orders.FirstOrDefault(item => item.Id == order.Id);

            if (entity != null)
            {
                entity.ShippingAddressId = order.ShippingAddressId;

                _dbContext.SaveChanges();
            }
            return true;
        }

        public IEnumerable<Order> GetAllOrderByUser(int userid)
        {
            return _dbContext.Orders.AsEnumerable();
        }
    }
}
