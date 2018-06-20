namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDepartments : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Departments (Name, Budget, StartDate, InstructorId) VALUES ('Department of Natural Science', 100000, 2018-01-01, 3)");
        }
        
        public override void Down()
        {
        }
    }
}
