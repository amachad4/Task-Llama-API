using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using FluentValidation;
using Application.Core;
using Application.ActionResult;

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
                    
                    var errorResponse = new Dictionary<string, SaveError>()
                    {
                        {"error", new SaveError{ StatusCode= 500, StatusText="Could not create the activity" }}
                    };
                    return Result<Unit>.Failure(errorResponse);
                };
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}