namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Operations", "Summ", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Operations", "Summ", c => c.Int(nullable: false));
        }
    }
}
