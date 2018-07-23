using Data.Infrastructure;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ItemMasterRepository : RepositoryBase<ItemMaster>, IItemMasterRepository
    {
        public ItemMasterRepository(IDbFactory dbFactory) : base(dbFactory) { }

        //public int GetByDayTime(int day, int time)
        //{
            //return 0;
            //return DbContext.Schedules.Where(s => s.Day == day && s.Time == time).Select(s => s.Id).FirstOrDefault();

        //}

        //public DbSet<ItemMaster> GetTable()
        //{
        //    return DbContext.ItemMasters;
        //}
    }

    public interface IItemMasterRepository : IRepository<ItemMaster>
    {
        //int GetByDayTime(int day, int time);
       // DbSet<ItemMaster> GetTable();
    }
}
