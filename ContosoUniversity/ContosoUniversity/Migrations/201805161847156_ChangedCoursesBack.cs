namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCoursesBack : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DepartmentCourses", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.DepartmentCourses", "Course_Id", "dbo.Courses");
            DropIndex("dbo.DepartmentCourses", new[] { "Department_Id" });
            DropIndex("dbo.DepartmentCourses", new[] { "Course_Id" });
            AddColumn("dbo.Courses", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "DepartmentId");
            AddForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            DropTable("dbo.DepartmentCourses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DepartmentCourses",
                c => new
                    {
                        Department_Id = c.Int(nullable: false),
                        Course_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Department_Id, t.Course_Id });
            
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropColumn("dbo.Courses", "DepartmentId");
            CreateIndex("dbo.DepartmentCourses", "Course_Id");
            CreateIndex("dbo.DepartmentCourses", "Department_Id");
            AddForeignKey("dbo.DepartmentCourses", "Course_Id", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DepartmentCourses", "Department_Id", "dbo.Departments", "Id", cascadeDelete: true);
        }
    }
}
