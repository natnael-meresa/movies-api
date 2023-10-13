
using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.Features.Cinema.Commands.UpdateCinema;

public class UpdateCinemaCommandValidator : AbstractValidator<UpdateCinemaCommand>
{
    public UpdateCinemaCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
            
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

        RuleFor(p => p.Location)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

      
        RuleFor(p => p.PhoneNumber)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(12).WithMessage("{PropertyName} must not exceed 12 characters.");
    }
    
}