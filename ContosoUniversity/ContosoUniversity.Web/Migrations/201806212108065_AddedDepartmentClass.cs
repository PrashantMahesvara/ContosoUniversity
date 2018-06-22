namespace ContosoUniversity.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDepartmentClass : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Departments (Name, Budget, StartDate) VALUES ('Department of Natural Science', '100,00', '20180101')");
            Sql("INSERT INTO Departments (Name, Budget, StartDate) VALUES ('Department of Social Science', '100,00', '20180101')");
            Sql("INSERT INTO Departments (Name, Budget, StartDate) VALUES ('Department of Human Science', '100,00', '20180101')");
            Sql("INSERT INTO Departments (Name, Budget, StartDate) VALUES ('Department of Mechanical Science', '100,00', '20180101')");
            Sql("INSERT INTO Departments (Name, Budget, StartDate) VALUES ('Department of Computer Science', '100,00', '20180101')");
            Sql("INSERT INTO Departments (Name, Budget, StartDate) VALUES ('Department of Health and Nutrition', '100,00', '20180101')");
            Sql("INSERT INTO Departments (Name, Budget, StartDate) VALUES ('Department of Justice and Law', '100,00', '20180101')");
        }
        
        public override void Down()
        {
        }
    }
}
