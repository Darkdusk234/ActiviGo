using ActiviGoApi.Services.DTOs.AuthorizationDTOs;
using FluentValidation;

namespace ActiviGoApi.Services.Validation.DataValidation.AuthorizationDtoValidators
{
    public class RegisterDto_Validator : AbstractValidator<RegisterDTO>
    {
        public RegisterDto_Validator()
        {
            RuleFor(r => r.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(50).WithMessage("Username cannot exceed 50 characters.");

            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email is required.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");

            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
                .MaximumLength(100).WithMessage("Password cannot exceed 100 characters.");

            RuleFor(r => r.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MinimumLength(2).WithMessage("First name must be at least 2 characters long.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

            RuleFor(r => r.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MinimumLength(2).WithMessage("Last name must be at least 2 characters long.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(r => r.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required.")
                .LessThan(DateTime.Now).WithMessage("Date of birth must be in the past.")
                .LessThan(DateTime.Now.AddYears(-13)).WithMessage("You must be at least 13 years old to register.");
        }
    }
}
