using BlazorTrainingDemo.Data;
using MediatR;
using System;

namespace BlazorTrainingDemo.Modules.Products
{
    public record CreateProductCommand(Product Product) : IRequest;

    public record ProductCreatedEvent(Product Product) : INotification;

    public class Create : IRequestHandler<CreateProductCommand>
    {
        private readonly ApplicationDbContext _context;
        
        private readonly IMediator _mediator;

        public Create(ApplicationDbContext context,IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //Add into Product collections database
            _context.Products.Add(request.Product);
            

            await _mediator.Publish(new ProductCreatedEvent(request.Product), cancellationToken);
        }


    }
}
