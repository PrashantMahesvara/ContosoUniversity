namespace ContosoUniversity.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInstructorCourseToDbContext : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.InstructorCourses", newName: "InstructorCourse1");
            CreateTable(
                "dbo.InstructorCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        InstructorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Instructors", t => t.InstructorId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.InstructorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InstructorCourses", "InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.InstructorCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.InstructorCourses", new[] { "InstructorId" });
            DropIndex("dbo.InstructorCourses", new[] { "CourseId" });
            DropTable("dbo.InstructorCourses");
            RenameTable(name: "dbo.InstructorCourse1", newName: "InstructorCourses");
        }
    }
}
