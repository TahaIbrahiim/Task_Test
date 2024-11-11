using Microsoft.EntityFrameworkCore;

namespace Task_ANAS_Academy.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=Task_ANAS;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
