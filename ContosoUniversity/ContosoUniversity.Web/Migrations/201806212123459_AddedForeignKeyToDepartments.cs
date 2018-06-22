namespace ContosoUniversity.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKeyToDepartments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "InstructorId", c => c.Int());
            CreateIndex("dbo.Departments", "InstructorId");
            AddForeignKey("dbo.Departments", "InstructorId", "dbo.Instructors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "InstructorId", "dbo.Instructors");
            DropIndex("dbo.Departments", new[] { "InstructorId" });
            DropColumn("dbo.Departments", "InstructorId");
        }
    }
}
