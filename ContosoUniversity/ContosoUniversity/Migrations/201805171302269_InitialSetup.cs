namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InstructorCourses", "Instructor_Id", "dbo.Instructors");
            DropForeignKey("dbo.InstructorCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Instructors", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Enrollments", new[] { "Course_Id" });
            DropIndex("dbo.Instructors", new[] { "Department_Id" });
            DropIndex("dbo.InstructorCourses", new[] { "Instructor_Id" });
            DropIndex("dbo.InstructorCourses", new[] { "Course_Id" });
            DropColumn("dbo.Enrollments", "CourseId");
            RenameColumn(table: "dbo.Enrollments", name: "Course_Id", newName: "CourseId");
            AddColumn("dbo.Courses", "Information", c => c.String());
            AlterColumn("dbo.Enrollments", "CourseId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Enrollments", "CourseId");
            DropTable("dbo.Instructors");
            DropTable("dbo.Departments");
            DropTable("dbo.InstructorCourses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.InstructorCourses",
                c => new
                    {
                        Instructor_Id = c.Int(nullable: false),
                        Course_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Instructor_Id, t.Course_Id });
            
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
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstMiddleName = c.String(),
                        HireDate = c.DateTime(nullable: false),
                        Department_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            AlterColumn("dbo.Enrollments", "CourseId", c => c.Int(nullable: false));
            DropColumn("dbo.Courses", "Information");
            RenameColumn(table: "dbo.Enrollments", name: "CourseId", newName: "Course_Id");
            AddColumn("dbo.Enrollments", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.InstructorCourses", "Course_Id");
            CreateIndex("dbo.InstructorCourses", "Instructor_Id");
            CreateIndex("dbo.Instructors", "Department_Id");
            CreateIndex("dbo.Enrollments", "Course_Id");
            AddForeignKey("dbo.Instructors", "Department_Id", "dbo.Departments", "Id");
            AddForeignKey("dbo.InstructorCourses", "Course_Id", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InstructorCourses", "Instructor_Id", "dbo.Instructors", "Id", cascadeDelete: true);
        }
    }
}
