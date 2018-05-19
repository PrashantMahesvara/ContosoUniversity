namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDepartmentToCourseClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Department_Id1", c => c.Int());
            AddColumn("dbo.Courses", "DepartmentId_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Department_Id1");
            CreateIndex("dbo.Courses", "DepartmentId_Id");
            AddForeignKey("dbo.Courses", "Department_Id1", "dbo.Departments", "Id");
            AddForeignKey("dbo.Courses", "DepartmentId_Id", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "DepartmentId_Id", "dbo.Departments");
            DropForeignKey("dbo.Courses", "Department_Id1", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "DepartmentId_Id" });
            DropIndex("dbo.Courses", new[] { "Department_Id1" });
            DropColumn("dbo.Courses", "DepartmentId_Id");
            DropColumn("dbo.Courses", "Department_Id1");
        }
    }
}
