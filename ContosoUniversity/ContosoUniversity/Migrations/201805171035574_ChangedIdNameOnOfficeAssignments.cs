namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedIdNameOnOfficeAssignments : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.OfficeAssignments", new[] { "InstructorID" });
            CreateIndex("dbo.OfficeAssignments", "InstructorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.OfficeAssignments", new[] { "InstructorId" });
            CreateIndex("dbo.OfficeAssignments", "InstructorID");
        }
    }
}
