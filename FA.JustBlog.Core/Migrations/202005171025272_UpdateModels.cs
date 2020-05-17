namespace FA.JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Posts", name: "Short Description", newName: "ShortDescription");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Posts", name: "ShortDescription", newName: "Short Description");
        }
    }
}
