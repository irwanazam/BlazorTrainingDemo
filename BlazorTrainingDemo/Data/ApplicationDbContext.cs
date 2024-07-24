using BlazorTrainingDemo.Domains;
using BlazorTrainingDemo.Modules.Products;
using BlazorTrainingDemo.Modules.States;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorTrainingDemo.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Logs> Logs { get; set; }

        public DbSet<State> States { get; set; }
    }
}
