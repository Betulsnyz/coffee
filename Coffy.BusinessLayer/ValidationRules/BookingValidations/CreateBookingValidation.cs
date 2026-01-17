using Coffy.DtoLayer.BookingDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffy.BusinessLayer.ValidationRules.BookingValidations
{
    public class CreateBookingValidation:AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");

            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon Alanı Boş Geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Email Alanı Boş Geçilemez");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi Alanı Boş Geçilemez");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih Alanı Boş Geçilemez Lütfen Tarih Seçimi Yapınız");

            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Lütfen isim alanına en az 5 karekter veri girişi yapınız").MaximumLength(50).WithMessage("Lütfen isim alanına en fazla 50 kareter veri girişi yapınız.");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Lütfen açıklama alanına en fazla 500 kareter veri girişi yapınız.");

            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz");
        }
    }
}
