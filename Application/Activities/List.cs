using System;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<Result<Dictionary<string, List<Activity>>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<Dictionary<string, List<Activity>>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Result<Dictionary<string, List<Activity>>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var list = await _context.activities.ToListAsync();
                var dict = new Dictionary<string, List<Activity>>();
                dict.Add("data", list);
                return Result<Dictionary<string, List<Activity>>>.Success(dict);
            }
        }
    }
}