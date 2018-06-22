namespace ContosoUniversity.Web.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedInstructors : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Instructors (FirstName, MiddleName, LastName, HireDate) VALUES ('Niel', '', 'DeGrasse Tyson', '20180101')");
            Sql("INSERT INTO Instructors (FirstName, MiddleName, LastName, HireDate) VALUES ('Carl', '', 'Sagan', '20150101')");
            Sql("INSERT INTO Instructors (FirstName, MiddleName, LastName, HireDate) VALUES ('Mae', '', 'Jemison', '20180101')");
            Sql("INSERT INTO Instructors (FirstName, MiddleName, LastName, HireDate) VALUES ('Carolyn', '', 'Porco', '20180101')");
            Sql("INSERT INTO Instructors (FirstName, MiddleName, LastName, HireDate) VALUES ('Marie', '', 'Curie', '20180101')");
            Sql("INSERT INTO Instructors (FirstName, MiddleName, LastName, HireDate) VALUES ('Rosalind', '', 'Franklin', '20180101')");
            Sql("INSERT INTO Instructors (FirstName, MiddleName, LastName, HireDate) VALUES ('Heddy', '', 'Lamarr', '20180101')");
            Sql("INSERT INTO Instructors (FirstName, MiddleName, LastName, HireDate) VALUES ('Ada', '', 'Lovelace', '20180101')");
        }

        public override void Down()
        {
        }
    }
}
