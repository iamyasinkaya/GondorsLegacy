using FluentValidation;

namespace GondorsLegacy.Services.HotelInformation.Validations;

public class HotelValidator : AbstractValidator<Entities.Hotel>
{
    public HotelValidator()
    {
        RuleFor(h => h.Name)
                            .NotEmpty()
                            .WithMessage("Otel adı boş olamaz.");

        RuleFor(h => h.Description)
                                    .NotEmpty()
                                   .WithMessage("Otel Açıklaması boş bırakılamaz")
                                   .MaximumLength(2500)
                                   .MinimumLength(50);
        RuleFor(h => h.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Geçerli bir Otel Id belirtilmelidir.")
            .NotEqual(Guid.Parse("00000000-0000-0000-0000-000000000001"))
            .WithMessage("Geçerli bir Otel Id belirtilmelidir.");
    }
}
