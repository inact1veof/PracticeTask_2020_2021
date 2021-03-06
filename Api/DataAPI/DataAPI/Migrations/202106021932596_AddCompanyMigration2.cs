namespace DataAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rmse_Values", "AlgId", c => c.Int(nullable: false));
            AddColumn("dbo.Rmse_Values", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Rmse_Values", "Algoritm_Id");
            DropColumn("dbo.Rmse_Values", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rmse_Values", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rmse_Values", "Algoritm_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Rmse_Values", "Date");
            DropColumn("dbo.Rmse_Values", "AlgId");
        }
    }
}
