namespace T1809E.WAD.TEST101_TrangDM2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitTables2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Penalties", "Amount", c => c.Int(nullable: false));
            DropColumn("dbo.Penalties", "Money");
            DropColumn("dbo.Penalties", "PushUp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Penalties", "PushUp", c => c.Int(nullable: false));
            AddColumn("dbo.Penalties", "Money", c => c.Double(nullable: false));
            DropColumn("dbo.Penalties", "Amount");
        }
    }
}
