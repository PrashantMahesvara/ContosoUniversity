namespace ContosoUniversity.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStudentClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstMiddleName = c.String(),
                        EnrollmentDate = c.DateTime(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        SSN = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
