using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.SubActivities
{
    public class Details
    {
        public class Query : IRequest<SubActivity>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, SubActivity>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<SubActivity> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.sub_activities.FindAsync(request.Id);
            }
        }
    }
}