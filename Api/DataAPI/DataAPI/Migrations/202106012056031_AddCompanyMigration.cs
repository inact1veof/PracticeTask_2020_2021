namespace DataAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuperForecasts", "Algoritm", c => c.String());
            AddColumn("dbo.SuperForecasts", "RealValueId", c => c.Int(nullable: false));
            AddColumn("dbo.SuperForecasts", "DeviceId", c => c.Int(nullable: false));
            DropColumn("dbo.SuperForecasts", "AlgoritmNumb");
            DropColumn("dbo.SuperForecasts", "RealValue");
            DropColumn("dbo.SuperForecasts", "Device");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SuperForecasts", "Device", c => c.String());
            AddColumn("dbo.SuperForecasts", "RealValue", c => c.Single(nullable: false));
            AddColumn("dbo.SuperForecasts", "AlgoritmNumb", c => c.Int(nullable: false));
            DropColumn("dbo.SuperForecasts", "DeviceId");
            DropColumn("dbo.SuperForecasts", "RealValueId");
            DropColumn("dbo.SuperForecasts", "Algoritm");
        }
    }
}
