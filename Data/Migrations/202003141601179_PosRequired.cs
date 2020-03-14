namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PosRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Positions", "PositionName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Positions", "PositionName", c => c.String());
        }
    }
}
