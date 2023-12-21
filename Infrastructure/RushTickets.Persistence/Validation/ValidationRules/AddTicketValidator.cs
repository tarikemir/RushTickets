using FluentValidation;
using RushTickets.Persistence;

namespace RushTickets.Persistence
{
    public class AddTicketValidator : AbstractValidator<TicketDto>
    {
        public AddTicketValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The Name must not be empty.");
            RuleFor(x => x.Name).MinimumLength(15).WithMessage("Name must be at least 15 characters");
            RuleFor(x => x.Description).NotEmpty().WithMessage("The description must not be empty.");
            RuleFor(x => x.Description).MinimumLength(15).WithMessage("Description must be at least 15 characters");

        }

    }
}
