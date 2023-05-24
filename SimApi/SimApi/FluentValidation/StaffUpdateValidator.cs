using FluentValidation;
using SimodevApi.Dtos;

namespace SimodevApi.FluentValidation
{
    public class StaffUpdateValidator : AbstractValidator<StaffRequestDto>
    {
        public StaffUpdateValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı bos bırakılamaz");


            RuleFor(x => x.AddressLine1).NotEmpty().WithMessage("adress bilgisi boş bırakılamaz")
                 .Length(4, 50).WithMessage(" adres alanı 4 ile 50 karakter arasında olmalıdır");
        }
    }
}
