namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDepartment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Budget = c.Decimal(nullable: false, storeType: "money"),
                        StartDate = c.DateTime(nullable: false),
                        InstructorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instructors", t => t.InstructorId)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.OfficeAssignments",
                c => new
                    {
                        InstructorId = c.Int(nullable: false),
                        Location = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.InstructorId)
                .ForeignKey("dbo.Instructors", t => t.InstructorId)
                .Index(t => t.InstructorId);
            
            AddColumn("dbo.Courses", "Department_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Department_Id");
            AddForeignKey("dbo.Courses", "Department_Id", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Departments", "InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.OfficeAssignments", "InstructorId", "dbo.Instructors");
            DropIndex("dbo.OfficeAssignments", new[] { "InstructorId" });
            DropIndex("dbo.Departments", new[] { "InstructorId" });
            DropIndex("dbo.Courses", new[] { "Department_Id" });
            DropColumn("dbo.Courses", "Department_Id");
            DropTable("dbo.OfficeAssignments");
            DropTable("dbo.Departments");
        }
    }
}
