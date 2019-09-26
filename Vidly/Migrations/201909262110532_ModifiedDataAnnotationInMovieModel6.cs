namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedDataAnnotationInMovieModel6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
