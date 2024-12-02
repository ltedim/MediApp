using MediApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediApp
{
    public class MedsDbContext : DbContext
    {
        public MedsDbContext(DbContextOptions<MedsDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var meds = new List<Medicine>
                {
                    new() { Id = Guid.NewGuid(), Name = "Med1", Quantity = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Med2", Quantity = 0 }
                };

            modelBuilder.Entity<Medicine>().HasData(meds);
        }

        public DbSet<Medicine> Meds { get; set; }
    }
}
