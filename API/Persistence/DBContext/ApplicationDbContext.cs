using Microsoft.EntityFrameworkCore;
using API.Domain.Models;
using API.Persistence.Seeds;

namespace API.Persistence.DBContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<API.Domain.Models.API> APIs { get; set; }
        public DbSet<APIType> APITypes { get; set; }
        public DbSet<Body> Bodies { get; set; }
        public DbSet<BodyTag> BodyTags { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Header> Headers { get; set; }
        public DbSet<HeaderTag> HeaderTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<URL> URLs { get; set; }
        public DbSet<URLTag> URLTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new HTTPMethodsSeed());
            modelBuilder.ApplyConfiguration(new APITypeSeed());
        }


    }
}
