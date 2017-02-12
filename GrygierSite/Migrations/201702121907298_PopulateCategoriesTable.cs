namespace GrygierSite.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Id, Name) VALUES (1, 'Templates')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (2, 'Art')");
            Sql("INSERT INTO Categories (Id, Name, ParentCategoryId) VALUES (3, 'Backgrounds', 2)");
            Sql("INSERT INTO Categories (Id, Name, ParentCategoryId) VALUES (4, 'Characters', 2)");
            Sql("INSERT INTO Categories (Id, Name, ParentCategoryId) VALUES (5, 'GUI', 2)");
            Sql("INSERT INTO Categories (Id, Name, ParentCategoryId) VALUES (6, 'Icons', 2)");
            Sql("INSERT INTO Categories (Id, Name, ParentCategoryId) VALUES (7, 'Items', 2)");
            Sql("INSERT INTO Categories (Id, Name, ParentCategoryId) VALUES (8, 'Logo', 2)");
            Sql("INSERT INTO Categories (Id, Name, ParentCategoryId) VALUES (9, 'Obstacles', 2)");
        }

        public override void Down()
        {
            Sql("DELETE FROM Categories WHERE Id IN (1, 2, 3, 4, 5, 6, 7, 8, 9)");
        }
    }
}
