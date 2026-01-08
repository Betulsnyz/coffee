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
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(CoffyContext context) : base(context)
        {
        }

        public List<Notification> GetAllNotificationByFalse()
        {
            using var context = new CoffyContext();
            return context.Notifications.Where(x=>x.Status==false).ToList();
        }

        public int NotificationCountByStatusFalse()
        {
            using var context = new CoffyContext();
            return context.Notifications.Where(x=>x.Status==false).Count();
        }
    }
}
