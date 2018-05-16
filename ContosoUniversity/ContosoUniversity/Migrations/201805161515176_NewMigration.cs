namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OfficeAssignments", "InstructorId", "dbo.Instructors");
            DropIndex("dbo.OfficeAssignments", new[] { "InstructorId" });
            AddColumn("dbo.Courses", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "DepartmentId");
            AddForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            DropTable("dbo.OfficeAssignments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OfficeAssignments",
                c => new
                    {
                        InstructorId = c.Int(nullable: false),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.InstructorId);
            
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropColumn("dbo.Courses", "DepartmentId");
            CreateIndex("dbo.OfficeAssignments", "InstructorId");
            AddForeignKey("dbo.OfficeAssignments", "InstructorId", "dbo.Instructors", "Id");
        }
    }
}
