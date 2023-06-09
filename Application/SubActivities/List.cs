using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.SubActivities
{
    public class List
    {
        public class Query : IRequest<List<SubActivity>>
        {

        }
        public class Handler : IRequestHandler<Query, List<SubActivity>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context; 
            }
            public async Task<List<SubActivity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.sub_activities.ToListAsync();
            }
        }
    }
}