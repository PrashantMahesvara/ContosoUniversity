namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedStudents : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Gidlund', 'Andreas', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Brithén', 'Gustav', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Bernadotte', 'Karl', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Davidson',  'Gabriel', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Borell',  'Martin', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Leth',  'Michael', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Sjöstrand', 'Erik', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Daju',  'Radu', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Swensson',  'Henrik', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Larsson',  'Fredrik', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Lilja',  'Markus', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Ericsson',  'Henric', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Wall',  'Johan', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Hjalmarsson',  'Rickard', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Olsson',  'Jonas', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Ben Abbes',  'Tarek ', 2018-01-01, 2000-01-01, 'ACBB')");

            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Swensson',  'Elin ', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Karlsson', 'Linda ', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Romero',  'Denyse ', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Mattson',  'Lina ', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Andersson',  'Bitte ', 2018-01-01, 2000-01-01, 'ACBB')");
        }

        public override void Down()
        {
        }
    }
}
