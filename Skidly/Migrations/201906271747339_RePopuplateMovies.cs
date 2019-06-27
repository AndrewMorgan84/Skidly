namespace Skidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RePopuplateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Movies ON INSERT INTO Movies (Id, Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES (1, 'Twin Peaks', 2, 1980-04-25, 1979-04-25, 2) SET IDENTITY_INSERT Movies OFF");
            Sql("SET IDENTITY_INSERT Movies ON INSERT INTO Movies (Id, Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES (2, 'Wild At Heart', 7, 1980-04-25, 1979-04-25, 2) SET IDENTITY_INSERT Movies OFF");
            Sql("SET IDENTITY_INSERT Movies ON INSERT INTO Movies (Id, Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES (3, 'EraserHead', 8, 1980-04-25, 1979-04-25, 2) SET IDENTITY_INSERT Movies OFF");
            Sql("SET IDENTITY_INSERT Movies ON INSERT INTO Movies (Id, Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES (4, 'Mullholland Drive', 7, 1980-04-25, 1979-04-25, 2) SET IDENTITY_INSERT Movies OFF");
            Sql("SET IDENTITY_INSERT Movies ON INSERT INTO Movies (Id, Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES (5, 'Lost Highway', 2, 1980-04-25, 1979-04-25, 2) SET IDENTITY_INSERT Movies OFF");
            Sql("SET IDENTITY_INSERT Movies ON INSERT INTO Movies (Id, Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES (6, 'Dune', 6, 1980-04-25, 1979-04-25, 2) SET IDENTITY_INSERT Movies OFF");
        }
        
        public override void Down()
        {
        }
    }
}
