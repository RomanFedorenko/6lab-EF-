namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateToOperation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Operations", "date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Operations", "date");
        }
    }
}
