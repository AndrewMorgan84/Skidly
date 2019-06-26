namespace Skidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomerDateOfBirths : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET DateOfBirth = CAST('1984-07-18' AS DATETIME) WHERE Id = 1");
            Sql("UPDATE Customers SET DateOfBirth = CAST('1993-03-22' AS DATETIME) WHERE Id = 3");
            Sql("UPDATE Customers SET DateOfBirth = CAST('1980-06-03' AS DATETIME) WHERE Id = 4");
            Sql("UPDATE Customers SET DateOfBirth = CAST('1972-01-30' AS DATETIME) WHERE Id = 6");
        }
        
        public override void Down()
        {
        }
    }
}
