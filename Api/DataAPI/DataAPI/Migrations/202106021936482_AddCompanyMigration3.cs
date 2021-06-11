namespace DataAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rmse_Values", "DeviceId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rmse_Values", "DeviceId");
        }
    }
}
