using Domain;
using MediatR;
using Persistence;

namespace Application.SubActivities
{
    public class Create
    {
        public class Command : IRequest
        {
            public SubActivity SubActivity { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;  
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.sub_activities.Add(request.SubActivity);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}