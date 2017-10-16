using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MediaPlayer.Models
{
    public class MediaPlayerContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MediaPlayerContext() : base("name=MediaPlayerContext")
        {
        }

        public System.Data.Entity.DbSet<MediaPlayer.Models.Pjesma> Pjesmas { get; set; }
        public System.Data.Entity.DbSet<MediaPlayer.Models.Playlist> Playlists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pjesma>()
                            .HasMany<Playlist>(p => p.Playliste)
                            .WithMany(pl => pl.pjesme)
                            .Map(cs =>
                            {
                                cs.MapLeftKey("PjesmaId");
                                cs.MapRightKey("PlaylistId");
                                cs.ToTable("PjesmaPlaylist");
                            });
        }
    }

    
     
    


}
