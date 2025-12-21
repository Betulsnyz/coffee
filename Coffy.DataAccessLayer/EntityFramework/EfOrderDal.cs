using Coffy.DataAccessLayer.Abstract;
using Coffy.DataAccessLayer.Concrete;
using Coffy.DataAccessLayer.Repositories;
using Coffy.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffy.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(CoffyContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new CoffyContext();
            return context.Orders.Where(x => x.Description == "masada").Count();
        }

        public decimal LastOrderPrice()
        {
            using var context = new CoffyContext();
            return context.Orders.OrderByDescending(x => x.OrderID).Take(1).Select(y => y.TotalPrice).FirstOrDefault();
        }

        public decimal TodayTotalPrice()
        {
            return 0;        }

        public int TotalOrderCount()
        {
            using var context = new CoffyContext();
            return context.Orders.Count();
        }
    }
}
 