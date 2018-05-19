namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedDepartmentToCourseClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Department_Id1", "dbo.Departments");
            DropForeignKey("dbo.Courses", "DepartmentId_Id", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "Department_Id1" });
            DropIndex("dbo.Courses", new[] { "DepartmentId_Id" });
            DropColumn("dbo.Courses", "Department_Id1");
            DropColumn("dbo.Courses", "DepartmentId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "DepartmentId_Id", c => c.Int());
            AddColumn("dbo.Courses", "Department_Id1", c => c.Int());
            CreateIndex("dbo.Courses", "DepartmentId_Id");
            CreateIndex("dbo.Courses", "Department_Id1");
            AddForeignKey("dbo.Courses", "DepartmentId_Id", "dbo.Departments", "Id");
            AddForeignKey("dbo.Courses", "Department_Id1", "dbo.Departments", "Id");
        }
    }
}
