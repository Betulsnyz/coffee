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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(CoffyContext context) : base(context)
        {
        }

        public void BookingStatusApproved(int id)
        {
            using var context = new CoffyContext();
            var values = context.Bookings.Find(id);
            values.Description = "Rezervasyon Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusCancelled(int id)
        {
            using var context = new CoffyContext();
            var values = context.Bookings.Find(id);
            values.Description = "Rezervasyon İptal Edildi";
            context.SaveChanges();
        }

        public List<Booking> GetBookingStatusApproved()
        {
            var context = new CoffyContext();
            var values = context.Bookings.Where(x => x.Description == "Rezervasyon Onaylandı").ToList();
            return values;
        }

        public List<Booking> GetBookingStatusCanceled()
        {
            var context = new CoffyContext();
            var values = context.Bookings.Where(x => x.Description == "Rezervasyon İptal Edildi").ToList();
            return values;
        }

        public List<Booking> GetBookingStatusReceived()
        {
            var context = new CoffyContext();
            var values = context.Bookings.Where(x => x.Description == "Rezervasyon Alındı").ToList();
            return values;

        }
    }
}
