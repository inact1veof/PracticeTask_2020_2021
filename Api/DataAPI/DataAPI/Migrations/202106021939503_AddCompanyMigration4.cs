namespace DataAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Algoritm_Results", "DeviceId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Algoritm_Results", "DeviceId");
        }
    }
}
