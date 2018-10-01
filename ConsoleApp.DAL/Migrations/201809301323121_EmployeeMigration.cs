namespace ConsoleApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Breed = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employees", "HomeCat_Id", c => c.Int());
            CreateIndex("dbo.Employees", "HomeCat_Id");
            AddForeignKey("dbo.Employees", "HomeCat_Id", "dbo.Cats", "Id");
            DropColumn("dbo.Employees", "Catname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Catname", c => c.String());
            DropForeignKey("dbo.Employees", "HomeCat_Id", "dbo.Cats");
            DropIndex("dbo.Employees", new[] { "HomeCat_Id" });
            DropColumn("dbo.Employees", "HomeCat_Id");
            DropTable("dbo.Cats");
        }
    }
}
