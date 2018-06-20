namespace ContosoUniversity.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedCourses : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Courses (CourseCode, Title, Credits, Information) VALUES ('DNSCHY101', 'Basic Chemestry', 2, 'Beginner course in chemistry')");
            Sql("INSERT INTO Courses (CourseCode, Title, Credits, Information) VALUES ('DNSCHY102', 'Intermediate Chemestry', 3, 'Intermediate course in chemistry')");
            Sql("INSERT INTO Courses (CourseCode, Title, Credits, Information) VALUES ('DNSCHY103', 'Advanced Chemestry', 4, 'Advanced course in chemistry')");

            Sql("INSERT INTO Courses (CourseCode, Title, Credits, Information) VALUES ('DNSASY101', 'Basic Astronomy', 2, 'Beginner course in astronomy')");
            Sql("INSERT INTO Courses (CourseCode, Title, Credits, Information) VALUES ('DNSASY102', 'Intermediate Astronomy', 3, 'Beginner course in astronomy')");
            Sql("INSERT INTO Courses (CourseCode, Title, Credits, Information) VALUES ('DNSASY103', 'Advanced Astronomy', 4, 'Beginner course in astronomy')");

            Sql("INSERT INTO Courses (CourseCode, Title, Credits, Information) VALUES ('DNSBIY101', 'Basic Biology', 2, 'Beginner course in biology')");
            Sql("INSERT INTO Courses (CourseCode, Title, Credits, Information) VALUES ('DNSBIY102', 'Intermediate Biology', 3, 'Beginner course in biology')");
            Sql("INSERT INTO Courses (CourseCode, Title, Credits, Information) VALUES ('DNSBIY103', 'Advanced Biology', 4, 'Beginner course in biology')");

            Sql("INSERT INTO Courses (CourseCode, Title, Credits, Information) VALUES ('DNSPHY101', 'Basic Physics', 2, 'Beginner course in physics')");
            Sql("INSERT INTO Courses (CourseCode, Title, Credits, Information) VALUES ('DNSPHY102', 'Intermediate Physics', 3, 'Beginner course in physics')");
            Sql("INSERT INTO Courses (CourseCode, Title, Credits, Information) VALUES ('DNSPHY103', 'Advanced Physics', 4, 'Beginner course in physics')");

            Sql("INSERT INTO Courses (CourseCode, Title, Credits, Information) VALUES ('DNSEAE101', 'Basic Earth Science', 2, 'Beginner course in earth sciences')");
            Sql("INSERT INTO Courses (CourseCode, Title, Credits, Information) VALUES ('DNSEAE102', 'Intermediate Earth Science', 3, 'Beginner course in earth sciences')");
            Sql("INSERT INTO Courses (CourseCode, Title, Credits, Information) VALUES ('DNSEAE103', 'Advanced Earth Science', 4, 'Beginner course in earth sciences')");
        }

        public override void Down()
        {
        }
    }
}
