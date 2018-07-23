namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemMasterInventories",
                c => new
                    {
                        ItemMasterInventoryId = c.Int(nullable: false, identity: true),
                        Size = c.Int(nullable: false),
                        QtyOnHand = c.Int(nullable: false),
                        QtyAllocated = c.Int(nullable: false),
                        ItemMasterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemMasterInventoryId)
                .ForeignKey("dbo.ItemMasters", t => t.ItemMasterId, cascadeDelete: true)
                .Index(t => t.ItemMasterId);
            
            CreateTable(
                "dbo.ItemMasters",
                c => new
                    {
                        ItemMasterId = c.Int(nullable: false, identity: true),
                        Pack = c.Int(nullable: false),
                        Description = c.String(),
                        ImageData = c.String(),
                        HazardousMaterial = c.Boolean(nullable: true),
                        ExpirationDate = c.DateTime(nullable: true),
                        UnitPrice = c.Single(nullable: true),
                        Width = c.Single(nullable: true),
                        Length = c.Single(nullable: true),
                        Height = c.Single(nullable: true),
                        IsPrePack = c.Boolean(nullable: true),
                        PrePackStyte = c.String(),
                        CostCenterCode = c.String(),
                    })
                .PrimaryKey(t => t.ItemMasterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemMasterInventories", "ItemMasterId", "dbo.ItemMasters");
            DropIndex("dbo.ItemMasterInventories", new[] { "ItemMasterId" });
            DropTable("dbo.ItemMasters");
            DropTable("dbo.ItemMasterInventories");
        }
    }
}
