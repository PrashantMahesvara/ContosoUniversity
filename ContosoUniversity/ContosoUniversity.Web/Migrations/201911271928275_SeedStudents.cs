namespace ContosoUniversity.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedStudents : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Prashant', 'Mahesvara', '2000-01-01', '1982-10-08', 'ABCD')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Shirley', 'Valenzuela Vinoya', '2000-01-01', '1983-01-11', 'AACD')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Radu', 'Daju', '2000-01-01', '1982-10-08', 'AAAD')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Elin', 'Swensson', '2000-01-01', '1982-10-08', 'AAAA')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Erik', 'Sjöstrand', '2000-01-01', '1982-10-08', 'ABBD')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Linda', 'Jennifer Karlsson', '2000-01-01', '1982-10-08', 'ABBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Rickard', 'Tom Hjalmarsson', '2000-01-01', '1982-10-08', 'ABCC')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Jonas', 'Mikael Olsson', '2000-01-01', '1982-10-08', 'DDDD')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Martin', 'Borell', '2000-01-01', '1982-10-08', 'DDDC')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Mika', 'Leth', '2000-01-01', '1982-10-08', 'DDDB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Nathalie', 'Leth', '2000-01-01', '1982-10-08', 'DDDA')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Randi', 'Johansson', '2000-01-01', '1982-10-08', 'DDAA')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Lina', 'Neeta Mattson', '2000-01-01', '1982-10-08', 'DAAA')");

        }

        public override void Down()
        {
        }
    }
}
