using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EntitiesRetail : DbContext
    {
        public EntitiesRetail() : base("RetailEntity")
        {

        }
        public DbSet<ItemMaster> ItemMasters { get; set; }
        public DbSet<ItemMasterInventory> ItemMasterInventorys { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
