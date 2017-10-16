namespace MediaPlayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ispravakManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pjesmas", "Playlist_Id", "dbo.Playlists");
            DropIndex("dbo.Pjesmas", new[] { "Playlist_Id" });
            CreateTable(
                "dbo.PjesmaPlaylist",
                c => new
                    {
                        PjesmaId = c.Int(nullable: false),
                        PlaylistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PjesmaId, t.PlaylistId })
                .ForeignKey("dbo.Pjesmas", t => t.PjesmaId, cascadeDelete: true)
                .ForeignKey("dbo.Playlists", t => t.PlaylistId, cascadeDelete: true)
                .Index(t => t.PjesmaId)
                .Index(t => t.PlaylistId);
            
            DropColumn("dbo.Pjesmas", "Playlist_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pjesmas", "Playlist_Id", c => c.Int());
            DropForeignKey("dbo.PjesmaPlaylist", "PlaylistId", "dbo.Playlists");
            DropForeignKey("dbo.PjesmaPlaylist", "PjesmaId", "dbo.Pjesmas");
            DropIndex("dbo.PjesmaPlaylist", new[] { "PlaylistId" });
            DropIndex("dbo.PjesmaPlaylist", new[] { "PjesmaId" });
            DropTable("dbo.PjesmaPlaylist");
            CreateIndex("dbo.Pjesmas", "Playlist_Id");
            AddForeignKey("dbo.Pjesmas", "Playlist_Id", "dbo.Playlists", "Id");
        }
    }
}
