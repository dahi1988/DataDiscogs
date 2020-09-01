using Context.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Context
{
    public  class DiscogsContext : DbContext 
    {

        public DiscogsContext(DbContextOptions<DiscogsContext> options)
            : base(options)
        {
        }
        public DbSet<Image> Images {get; set;}
        public DbSet<Video> Videos {get; set;}
        #region Artist
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistAlias> ArtistAliases {get; set;}
        public DbSet<ArtistGroup> ArtistGroups {get; set;}
        public DbSet<ArtistImage> ArtistImages {get; set;}
        public DbSet<ArtistMember> ArtistMembers {get; set;}
        #endregion Artist

        #region Label
        public DbSet<Label> Labels {get; set;}
        public DbSet<LabelImage> LabelImages {get; set;}
        public DbSet<ParentLabel> ParentLabels {get; set;}
        public DbSet<SubLabel> SubLabels {get; set;}
        #endregion Label
        #region Master
        public DbSet<Master> Masters {get; set;}
        public DbSet<MasterImage> MasterImages {get; set;}
        public DbSet<MasterArtist> MasterArtists {get; set;}
        public DbSet<MasterVideo> MasterVideos {get; set;}
        #endregion Master
        
        public class DiscogsContextFactory : IDesignTimeDbContextFactory<DiscogsContext>
        {
            public DiscogsContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<DiscogsContext>()
                .UseSqlServer("Server=.;Database=Discogz;User Id=CasterStatsApp;Password=Test123=;");
                return new DiscogsContext(optionsBuilder.Options);
            }
        }
    }
}
