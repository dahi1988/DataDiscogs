using DiscogsContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Context
{
   public  class DiscogsContext : DbContext 
    {
       

        public DiscogsContext(DbContextOptions<DiscogsContext> options)
             : base(options)
        {
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Master> Masters { get; set; }
        public class DiscogsContextFactory : IDesignTimeDbContextFactory<DiscogsContext>
        {
            public DiscogsContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<DiscogsContext>()
                .UseSqlServer("Server=DESKTOP-5A54U6A;Database=DiscogsData;Trusted_Connection=True;MultipleActiveResultSets=true");
                return new DiscogsContext(optionsBuilder.Options);
            }
        }
    }
}
