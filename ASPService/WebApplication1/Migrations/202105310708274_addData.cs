namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String());
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "CompanyId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "DepartamentId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "PositionId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PositionId");
            DropColumn("dbo.AspNetUsers", "DepartamentId");
            DropColumn("dbo.AspNetUsers", "CompanyId");
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
