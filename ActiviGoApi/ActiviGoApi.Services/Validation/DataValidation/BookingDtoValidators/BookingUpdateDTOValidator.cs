using FluentValidation;
using ActiviGoApi.Services.DTOs;

public class BookingUpdateDTOValidator : AbstractValidator<BookingUpdateDTO>
{
    public BookingUpdateDTOValidator()
    {
        RuleFor(x => x.Participants)
            .InclusiveBetween(1, 50)
            .WithMessage("Participants must be between 1 and 50.");

        RuleFor(x => x)
            .Must(dto => !(dto.IsCancelled && dto.ParticipationConfirmed))
            .WithMessage("A booking cannot be both cancelled and confirmed.");
        // Om man ska updatera en bokning till betald måste den också vara satt till inaktiv
        RuleFor(x => x)
            .Must(dto => !(dto.IsPaid && !dto.IsActive))
            .WithMessage("A paid booking cannot be marked as inactive.");

    }
}
