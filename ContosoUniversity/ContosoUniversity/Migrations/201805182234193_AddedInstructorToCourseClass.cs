namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInstructorToCourseClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Instructor_Id", "dbo.Instructors");
            DropIndex("dbo.Courses", new[] { "Instructor_Id" });
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
            
            DropColumn("dbo.Courses", "Instructor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Instructor_Id", c => c.Int());
            DropForeignKey("dbo.InstructorCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.InstructorCourses", "Instructor_Id", "dbo.Instructors");
            DropIndex("dbo.InstructorCourses", new[] { "Course_Id" });
            DropIndex("dbo.InstructorCourses", new[] { "Instructor_Id" });
            DropTable("dbo.InstructorCourses");
            CreateIndex("dbo.Courses", "Instructor_Id");
            AddForeignKey("dbo.Courses", "Instructor_Id", "dbo.Instructors", "Id");
        }
    }
}
