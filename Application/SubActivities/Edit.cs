using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.SubActivities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public SubActivity SubActivity { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var subActivity = await _context.sub_activities.FindAsync(request.SubActivity.Id);
                _mapper.Map(request.SubActivity, subActivity);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}