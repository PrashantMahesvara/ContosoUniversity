namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDepartmentToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        InstructorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Instructors", "Department_Id", c => c.Int());
            CreateIndex("dbo.Instructors", "Department_Id");
            AddForeignKey("dbo.Instructors", "Department_Id", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instructors", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Instructors", new[] { "Department_Id" });
            DropColumn("dbo.Instructors", "Department_Id");
            DropTable("dbo.Departments");
        }
    }
}
