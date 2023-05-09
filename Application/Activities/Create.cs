using Domain;
using MediatR;
using Persistence;
using FluentValidation;
using Application.Core;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Activity Activity { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.activities.Add(request.Activity);
                var result = await _context.SaveChangesAsync() > 0;
                if(result)
                {
                    return Result<Unit>.Failure(new SaveError("Failed to create the Activity"));
                };
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}