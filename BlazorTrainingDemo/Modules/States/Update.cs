using BlazorTrainingDemo.Data;
using BlazorTrainingDemo.Domains;
using MediatR;

namespace BlazorTrainingDemo.Modules.States
{
    public record UpdateStateCommand(State State) : IRequest;

    public record StateUpdatedEvent(State State) : INotification;

    public class Update : IRequestHandler<UpdateStateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;
        public Update(ApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task Handle(UpdateStateCommand request, CancellationToken cancellationToken)
        {
            State? state = await _context.States.FindAsync(request.State.Id);
            if (state == null)
            {
                throw new Exception("State not found");
            }
            else
            {
                state.Name = request.State.Name;
                state.Capital = request.State.Capital;
                state.QuotaTrainee = request.State.QuotaTrainee;
                _context.States.Update(request.State);
            }

            await _mediator.Publish(new StateUpdatedEvent(request.State), cancellationToken);
        }


    }
}
