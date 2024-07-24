using BlazorTrainingDemo.Data;
using BlazorTrainingDemo.Domains;
using MediatR;
using System;

namespace BlazorTrainingDemo.Modules.States
{
    public record CreateStateCommand(State State) : IRequest;

    public record StateCreatedEvent(State State) : INotification;

    public class Create : IRequestHandler<CreateStateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;
        public Create(ApplicationDbContext context,IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task Handle(CreateStateCommand request, CancellationToken cancellationToken)
        {
            _context.States.Add(request.State);
            
            await _mediator.Publish(new StateCreatedEvent(request.State), cancellationToken);
        }


    }
}
