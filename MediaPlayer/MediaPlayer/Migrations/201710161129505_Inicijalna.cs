namespace MediaPlayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicijalna : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pjesmas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lokacija = c.String(),
                        Naziv = c.String(),
                        Zanr = c.String(),
                        Artist = c.String(),
                        Album = c.String(),
                        TrackNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pjesmas");
        }
    }
}
