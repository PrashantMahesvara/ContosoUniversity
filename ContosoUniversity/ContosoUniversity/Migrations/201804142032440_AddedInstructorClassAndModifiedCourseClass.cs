namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInstructorClassAndModifiedCourseClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstMiddleName = c.String(),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InstructorCourses",
                c => new
                    {
                        Instructor_Id = c.Int(nullable: false),
                        Course_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Instructor_Id, t.Course_Id })
                .ForeignKey("dbo.Instructors", t => t.Instructor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Instructor_Id)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InstructorCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.InstructorCourses", "Instructor_Id", "dbo.Instructors");
            DropIndex("dbo.InstructorCourses", new[] { "Course_Id" });
            DropIndex("dbo.InstructorCourses", new[] { "Instructor_Id" });
            DropTable("dbo.InstructorCourses");
            DropTable("dbo.Instructors");
        }
    }
}
