using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffy.DtoLayer.TestimonialDto
{
    public class CreateTestimonialDto
    {
        public String Name { get; set; }
        public String Title { get; set; }
        public String Comment { get; set; }
        public String ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
