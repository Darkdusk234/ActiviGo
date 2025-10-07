using FluentValidation;
using ActiviGoApi.Services.DTOs;

public class BookingCreateDTOValidator : AbstractValidator<BookingCreateDTO>
{
    public BookingCreateDTOValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .GreaterThan(0).WithMessage("UserId must be greater than 0.");

        RuleFor(x => x.ActivityOccurenceId)
            .NotEmpty().WithMessage("ActivityOccurenceId is required.")
            .GreaterThan(0).WithMessage("ActivityOccurenceId must be greater than 0.");

        RuleFor(x => x.Participants)
            .InclusiveBetween(1, 50)
            .WithMessage("Participants must be between 1 and 50.");
    }
}
