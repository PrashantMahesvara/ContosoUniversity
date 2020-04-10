namespace ContosoUniversity.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCourses : DbMigration
    {
        public override void Up()
        {
            //Spell casting, departmentId 4
            Sql("INSER INTO Course('CourseCode', 'Title', 'Credits', 'Information', 'DepartmentId') VALUES ('SC101','Spell casting 101', 1, 'Introduction course to spell casting', 4");
            Sql("INSER INTO Course('CourseCode', 'Title', 'Credits', 'Information', 'DepartmentId') VALUES ('SC102','Spell casting 102', 2, 'Advanced course in spell casting', 4");
            Sql("INSER INTO Course('CourseCode', 'Title', 'Credits', 'Information', 'DepartmentId') VALUES ('SC103','Spell casting 103', 3, 'Master course in spell casting', 4");
            Sql("INSER INTO Course('CourseCode', 'Title', 'Credits', 'Information', 'DepartmentId') VALUES ('SC104','Spell casting 104', 4, 'High-level magic studies', 4");
            Sql("INSER INTO Course('CourseCode', 'Title', 'Credits', 'Information', 'DepartmentId') VALUES ('SC105','Spell casting 105', 5, 'Collaborative magics and magecrafts', 4");

            //Archeology, departmentId 5
            Sql("INSER INTO Course('CourseCode', 'Title', 'Credits', 'Information', 'DepartmentId') VALUES ('AY101','Archeology 101', 3, 'Introduction course in archeology', 5");


        }

        public override void Down()
        {
        }
    }
}


//CourseCode = string