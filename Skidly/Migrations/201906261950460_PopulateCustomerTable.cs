namespace Skidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomerTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers (Name,IsSubscribedToNewsLetter,MembershipTypeId) VALUES ('John Robertson',0,1)");
            Sql("INSERT INTO Customers (Name,IsSubscribedToNewsLetter,MembershipTypeId) VALUES ('Maggie Johnson',0,2)");
            Sql("INSERT INTO Customers (Name,IsSubscribedToNewsLetter,MembershipTypeId) VALUES ('Denise Jones',1,4)");
            Sql("INSERT INTO Customers (Name,IsSubscribedToNewsLetter,MembershipTypeId) VALUES ('Mark Preston',1,3)");
            Sql("INSERT INTO Customers (Name,IsSubscribedToNewsLetter,MembershipTypeId) VALUES ('Zach Davidson',1,2)");
            Sql("INSERT INTO Customers (Name,IsSubscribedToNewsLetter,MembershipTypeId) VALUES ('Til Lindemann',0,1)");
        }
        
        public override void Down()
        {
        }
    }
}
