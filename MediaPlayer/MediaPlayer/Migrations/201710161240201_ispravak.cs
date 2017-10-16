namespace MediaPlayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ispravak : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NazivPlayLista = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Pjesmas", "Playlist_Id", c => c.Int());
            CreateIndex("dbo.Pjesmas", "Playlist_Id");
            AddForeignKey("dbo.Pjesmas", "Playlist_Id", "dbo.Playlists", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pjesmas", "Playlist_Id", "dbo.Playlists");
            DropIndex("dbo.Pjesmas", new[] { "Playlist_Id" });
            DropColumn("dbo.Pjesmas", "Playlist_Id");
            DropTable("dbo.Playlists");
        }
    }
}
