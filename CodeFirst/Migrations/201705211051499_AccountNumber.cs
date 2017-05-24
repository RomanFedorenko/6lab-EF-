namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "AccNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "AccNumber");
        }
    }
}
