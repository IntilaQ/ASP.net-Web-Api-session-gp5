namespace WebAPIsession5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departements",
                c => new
                    {
                        DepartementId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DepartementId);
            
            CreateTable(
                "dbo.Materiels",
                c => new
                    {
                        MaterielId = c.Int(nullable: false, identity: true),
                        Libille = c.String(),
                        Number = c.Int(nullable: false),
                        DepartementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaterielId)
                .ForeignKey("dbo.Departements", t => t.DepartementId, cascadeDelete: true)
                .Index(t => t.DepartementId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Departement_DepartementId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departements", t => t.Departement_DepartementId)
                .Index(t => t.Departement_DepartementId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Departement_DepartementId", "dbo.Departements");
            DropForeignKey("dbo.Materiels", "DepartementId", "dbo.Departements");
            DropIndex("dbo.Employees", new[] { "Departement_DepartementId" });
            DropIndex("dbo.Materiels", new[] { "DepartementId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Materiels");
            DropTable("dbo.Departements");
        }
    }
}
