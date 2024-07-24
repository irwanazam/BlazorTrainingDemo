using BlazorTrainingDemo.Data;
using MediatR;

namespace BlazorTrainingDemo.Modules.Products
{
    public record UpdateProductCommand(Product Product) : IRequest;

    public record ProductUpdatedEvent(Product Product) : INotification;

    public class Update : IRequestHandler<UpdateProductCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;
        public Update(ApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _context.Products.FindAsync(request.Product.Id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            else
            {
                product.Name = request.Product.Name;
                product.Code = request.Product.Code;
                product.Description = request.Product.Description;
                _context.Products.Update(request.Product);
            }

            await _mediator.Publish(new ProductUpdatedEvent(request.Product), cancellationToken);
        }


    }
}
