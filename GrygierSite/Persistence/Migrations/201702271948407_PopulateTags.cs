namespace GrygierSite.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateTags : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Tags ON");
            Sql("INSERT INTO Tags (Id, Name) VALUES (1, 'Art')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (2, 'Background')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (3, 'Character')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (4, 'Enemy')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (5, 'Game')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (6, 'Item')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (7, 'Sale')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (8, 'Construct 2')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (9, 'Recent')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (10, 'Freebie')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (11, 'Web')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (12, 'HTML5')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (13, 'Mobile')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (14, 'Unity3D')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (15, 'Unreal Engine')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (16, 'Action')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (17, 'Adventure')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (18, 'Platform')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (19, 'Arcade')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (20, 'Trivia')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (21, 'Survival')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (22, 'RPG')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (23, 'Fantasy')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (24, 'Strategy')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (25, 'Racing')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (26, 'Sports')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (27, 'Casual')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (28, 'Logic')");
            Sql("INSERT INTO Tags (Id, Name) VALUES (29, 'Vector')");
            Sql("SET IDENTITY_INSERT Tags OFF");
        }

        public override void Down()
        {
            Sql("DELETE FROM Tags WHERE Id BETWEEN 1 and 29");
        }
    }
}
