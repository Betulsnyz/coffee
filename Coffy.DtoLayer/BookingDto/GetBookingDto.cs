using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffy.DtoLayer.BookingDto
{
    public class GetBookingDto
    {
        public int BookingID { get; set; }
        public String Name { get; set; }
        public String Phone { get; set; }
        public String Mail { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
    }
}
