using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Details
    {
        public class Query: IRequest<Result<Dictionary<string, Activity>>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Dictionary<string, Activity>>>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Result<Dictionary<string, Activity>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await _context.activities.FindAsync(request.Id);
                var dict = new Dictionary<string, Activity>();
                dict.Add("data", activity);
                return Result<Dictionary<string, Activity>>.Success(dict);
            }
        }
    }
}