namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCourseClassIdToString : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            DropPrimaryKey("dbo.Courses");
            AddColumn("dbo.Enrollments", "Course_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Courses", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Courses", "Id");
            CreateIndex("dbo.Enrollments", "Course_Id");
            AddForeignKey("dbo.Enrollments", "Course_Id", "dbo.Courses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Enrollments", new[] { "Course_Id" });
            DropPrimaryKey("dbo.Courses");
            AlterColumn("dbo.Courses", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Enrollments", "Course_Id");
            AddPrimaryKey("dbo.Courses", "Id");
            CreateIndex("dbo.Enrollments", "CourseId");
            AddForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
