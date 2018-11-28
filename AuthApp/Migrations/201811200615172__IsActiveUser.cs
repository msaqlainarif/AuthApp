namespace AuthApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _IsActiveUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsActive", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsActive");
        }
    }
}
