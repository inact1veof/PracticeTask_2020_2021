namespace DataAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Algoritm_Names",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Algoritm_Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Algoritm_Id = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Burden_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Forecasts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlgoritmNumb = c.Int(nullable: false),
                        DateForForecast = c.DateTime(nullable: false),
                        ValueId = c.Int(nullable: false),
                        RealValueId = c.Int(nullable: false),
                        RmseValueId = c.Int(nullable: false),
                        DeviceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RealValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date_Time = c.DateTime(nullable: false),
                        Value = c.Single(nullable: false),
                        Device_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rmse_Values",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Algoritm_Id = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SuperForecasts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlgoritmNumb = c.Int(nullable: false),
                        DateForForecast = c.DateTime(nullable: false),
                        Value = c.Single(nullable: false),
                        RealValue = c.Single(nullable: false),
                        RmseValue = c.Single(nullable: false),
                        Device = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SuperForecasts");
            DropTable("dbo.Rmse_Values");
            DropTable("dbo.RealValues");
            DropTable("dbo.Forecasts");
            DropTable("dbo.Devices");
            DropTable("dbo.Algoritm_Results");
            DropTable("dbo.Algoritm_Names");
        }
    }
}
