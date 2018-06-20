namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedEnrollments : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Enrollments (CourseId, StudentId, Grade) VALUES (1, 1, 2)");
            Sql("INSERT INTO Enrollments (CourseId, StudentId, Grade) VALUES (2, 1, 2)");
            Sql("INSERT INTO Enrollments (CourseId, StudentId, Grade) VALUES (4, 1, 2)");
            Sql("INSERT INTO Enrollments (CourseId, StudentId, Grade) VALUES (5, 1, 2)");
            Sql("INSERT INTO Enrollments (CourseId, StudentId, Grade) VALUES (10, 1, 2)");
            Sql("INSERT INTO Enrollments (CourseId, StudentId, Grade) VALUES (13, 1, 2)");

            Sql("INSERT INTO Enrollments (CourseId, StudentId, Grade) VALUES (1, 2, 2)");
            Sql("INSERT INTO Enrollments (CourseId, StudentId, Grade) VALUES (2, 2, 2)");
            Sql("INSERT INTO Enrollments (CourseId, StudentId, Grade) VALUES (4, 2, 2)");
            Sql("INSERT INTO Enrollments (CourseId, StudentId, Grade) VALUES (5, 2, 2)");
            Sql("INSERT INTO Enrollments (CourseId, StudentId, Grade) VALUES (10, 2, 2)");
            Sql("INSERT INTO Enrollments (CourseId, StudentId, Grade) VALUES (13, 2, 2)");

            Sql("INSERT INTO Enrollments (CourseId, StudentId, Grade) VALUES (1, 3, 2)");
            Sql("INSERT INTO Enrollments (CourseId, StudentId, Grade) VALUES (2, 3, 2)");
            Sql("INSERT INTO Enrollments (CourseId, StudentId, Grade) VALUES (4, 3, 2)");
            Sql("INSERT INTO Enrollments (CourseId, StudentId, Grade) VALUES (5, 3, 2)");
            Sql("INSERT INTO Enrollments (CourseId, StudentId, Grade) VALUES (10, 3, 2)");
            Sql("INSERT INTO Enrollments (CourseId, StudentId, Grade) VALUES (13, 3, 2)");






        }

        public override void Down()
        {
        }
    }
}
