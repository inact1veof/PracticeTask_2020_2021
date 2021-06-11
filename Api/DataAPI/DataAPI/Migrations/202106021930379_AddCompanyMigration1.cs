namespace DataAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Algoritm_Results", "DeviceId");
            DropColumn("dbo.Rmse_Values", "DeviceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rmse_Values", "DeviceId", c => c.Int(nullable: false));
            AddColumn("dbo.Algoritm_Results", "DeviceId", c => c.Int(nullable: false));
        }
    }
}
