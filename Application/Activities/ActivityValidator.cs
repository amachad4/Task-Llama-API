using Domain;
using FluentValidation;

namespace Application.Activities
{
    public class ActivityValidator : AbstractValidator<Activity>
    {
        public ActivityValidator()
        {
            RuleFor(x => x.title).NotEmpty();
            RuleFor(x => x.deadline).NotEmpty();
            RuleFor(x => x.created_at).NotEmpty();
            RuleFor(x => x.category_lkp_id).NotEmpty();
        }
    }
}