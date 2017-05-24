namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumberAccUnique : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Accounts", "AccNumber", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Accounts", new[] { "AccNumber" });
        }
    }
}
