using BlazorTrainingDemo.Data;
using BlazorTrainingDemo.Modules.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorTrainingDemo.Modules.States
{
    public record GetStatesQuery() : IRequest<List<State>>;

    public class GetStatesHandler : IRequestHandler<GetStatesQuery, List<State>>
    {
        private readonly ApplicationDbContext _context;


        public GetStatesHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<State>> Handle(GetStatesQuery request, CancellationToken cancellationToken)
        {
            //Validation or other business processes

            return await _context.States.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
