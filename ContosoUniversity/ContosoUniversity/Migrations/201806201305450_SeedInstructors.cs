namespace ContosoUniversity.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedInstructors : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Instructors (LastName, FirstMiddleName, HireDate) VALUES ('Mahesvara', 'Prashant', 2015-01-01)");
            Sql("INSERT INTO Instructors (LastName, FirstMiddleName, HireDate) VALUES ('Croft', 'Lara', 2015-01-01)");
            Sql("INSERT INTO Instructors (LastName, FirstMiddleName, HireDate) VALUES ('Silverwood', 'Valerie', 2015-01-01)");
            Sql("INSERT INTO Instructors (LastName, FirstMiddleName, HireDate) VALUES ('Gupta', 'Maya', 2015-01-01)");
            Sql("INSERT INTO Instructors (LastName, FirstMiddleName, HireDate) VALUES ('Bigbutt', 'Madison', 2015-01-01)");
            Sql("INSERT INTO Instructors (LastName, FirstMiddleName, HireDate) VALUES ('Fatwaddle', 'Pengy', 2015-01-01)");
            Sql("INSERT INTO Instructors (LastName, FirstMiddleName, HireDate) VALUES ('DeGrasse Tyson', 'Neil', 2015-01-01)");
            Sql("INSERT INTO Instructors (LastName, FirstMiddleName, HireDate) VALUES ('Nye', 'Bill', 2015-01-01)");
            Sql("INSERT INTO Instructors (LastName, FirstMiddleName, HireDate) VALUES ('Porco', 'Carolyn', 2015-01-01)");
            Sql("INSERT INTO Instructors (LastName, FirstMiddleName, HireDate) VALUES ('Sagan', 'Carl', 2015-01-01)");
            Sql("INSERT INTO Instructors (LastName, FirstMiddleName, HireDate) VALUES ('Nichols', 'Nichelle', 2015-01-01)");
            Sql("INSERT INTO Instructors (LastName, FirstMiddleName, HireDate) VALUES ('Crusher', 'Beverly', 2015-01-01)");
            Sql("INSERT INTO Instructors (LastName, FirstMiddleName, HireDate) VALUES ('Troi', 'Deanna', 2015-01-01)");
            Sql("INSERT INTO Instructors (LastName, FirstMiddleName, HireDate) VALUES ('Diaz', 'Rosa', 2015-01-01)");
            Sql("INSERT INTO Instructors (LastName, FirstMiddleName, HireDate) VALUES ('Santiago', 'Amy', 2015-01-01)");
            Sql("INSERT INTO Instructors (LastName, FirstMiddleName, HireDate) VALUES ('Linetti', 'Gina', 2015-01-01)");

        }

        public override void Down()
        {
        }
    }
}
