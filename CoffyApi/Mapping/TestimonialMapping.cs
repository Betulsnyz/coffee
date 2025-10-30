using AutoMapper;
using Coffy.DtoLayer.TestimonialDto;
using Coffy.EntityLayer.Entities;

namespace CoffyApi.Mapping
{
    public class TestimonialMapping :Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
        }
    }
}
