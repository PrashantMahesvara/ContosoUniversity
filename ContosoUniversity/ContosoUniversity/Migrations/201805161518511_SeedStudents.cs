namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedStudents : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Andersson', 'Anders', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Bengtsson', 'Bengt', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Carlsson', 'Carl', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Danielsson', 'Daniel', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Eriksson', 'Erik', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Fridolfsson', 'Fridolf', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Gerhardsson', 'Gerhard', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Hansson', 'Hans', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Israelsson', 'Israel', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Jansson', 'Jan', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Klaesson', 'Klaes', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Larsson', 'Lars', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Martinsson', 'Martin', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Nilsson', 'Nils', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Orvarsson', 'Orvar', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Persson', 'Per', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Qvintusson', 'Qvintus', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Rolfsson', 'Rolf', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Samuelsson', 'Samuel', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Torvaldsson', 'Torvald', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Ulfsson', 'Ulf', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Valdermarsson', 'Valdemar', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Williamsson', 'William', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Xasansson', 'Xasan', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Yngwesson', 'Yngwe', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Zlatkosson', 'Zlatko', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Åkesson', 'Åke', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Ägirsson', 'Ägir', 2018-01-01, 2000-01-01, 'ACBB')");
            Sql("INSERT INTO Students (LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN) VALUES ('Östensson', 'Östen', 2018-01-01, 2000-01-01, 'ACBB')");
        }

        public override void Down()
        {
        }
    }
}
