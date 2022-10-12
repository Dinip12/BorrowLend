namespace BorrowLend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expanses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpenseName = c.String(nullable: false),
                        Amount = c.Int(nullable: false),
                        ExpenseTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseType", t => t.ExpenseTypeId, cascadeDelete: true)
                .Index(t => t.ExpenseTypeId);
            
            CreateTable(
                "dbo.ExpenseType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpenseTypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expanses", "ExpenseTypeId", "dbo.ExpenseType");
            DropIndex("dbo.Expanses", new[] { "ExpenseTypeId" });
            DropTable("dbo.ExpenseType");
            DropTable("dbo.Expanses");
        }
    }
}
