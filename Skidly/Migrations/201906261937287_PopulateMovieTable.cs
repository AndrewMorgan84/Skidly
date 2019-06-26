namespace Skidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name) VALUES ('Lost Highway')");
            Sql("INSERT INTO Movies (Name) VALUES ('Mulholland Drive')");
            Sql("INSERT INTO Movies (Name) VALUES ('Eraserhead')");
            Sql("INSERT INTO Movies (Name) VALUES ('Wild At Heart')");
            Sql("INSERT INTO Movies (Name) VALUES ('Blue velvet')");
            Sql("INSERT INTO Movies (Name) VALUES ('Mullholland Drive')");
            Sql("INSERT INTO Movies (Name) VALUES ('Twin Peaks')");
            Sql("INSERT INTO Movies (Name) VALUES ('The Elephant Man')");
        }
        
        public override void Down()
        {
        }
    }
}
