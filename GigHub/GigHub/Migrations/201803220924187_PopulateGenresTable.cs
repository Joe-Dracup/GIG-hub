namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Jazz')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Blues')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Country')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Hip-Hop')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Punk')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Trance')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id IN (1,2,3,4,5,6)");
        }
    }
}
