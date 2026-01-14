using Coffy.BusinessLayer.Abstract;
using Coffy.DataAccessLayer.Abstract;
using Coffy.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffy.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void TAdd(Booking entity)
        {
            _bookingDal.Add(entity);
        }

        public void TBookingStatusApproved(int id)
        {
            _bookingDal.BookingStatusApproved(id);
        }

        public void TBookingStatusCancelled(int id)
        {
            _bookingDal.BookingStatusCancelled(id);
        }

        public void TDelete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public List<Booking> TGetBookingStatusApproved()
        {
            return _bookingDal.GetBookingStatusApproved();
        }

        public List<Booking> TGetBookingStatusCanceled()
        {
            return _bookingDal.GetBookingStatusCanceled();
        }

        public List<Booking> TGetBookingStatusReceived()
        {
            return _bookingDal.GetBookingStatusReceived();
        }

        public Booking TGetbyID(int id)
        {
           return _bookingDal.GetbyID(id);
        }

        public List<Booking> TGetListAll()
        {
            return _bookingDal.GetListAll();
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
