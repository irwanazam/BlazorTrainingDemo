using BlazorTrainingDemo.Data;
using BlazorTrainingDemo.Domains;
using BlazorTrainingDemo.Modules.Products;
using MediatR;

namespace BlazorTrainingDemo.Modules.Audits
{
    public class Action : 
        INotificationHandler<ProductCreatedEvent>,
        INotificationHandler<ProductUpdatedEvent>
    {
        private readonly ApplicationDbContext _context;
      
        public Action(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ProductCreatedEvent evt, CancellationToken cancellationToken)
        {
            try
            {
                _context.Logs.Add(new Logs
                {
                    Message = $"Product create {evt.Product.Name}",
                    EventType = evt.GetType().Name,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System"
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }

        public async Task Handle(ProductUpdatedEvent evt, CancellationToken cancellationToken)
        {
            try
            {
                _context.Logs.Add(new Logs
                {
                    Message = $"Product update {evt.Product.Name}",
                    EventType = evt.GetType().Name,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System"
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


    }
}
