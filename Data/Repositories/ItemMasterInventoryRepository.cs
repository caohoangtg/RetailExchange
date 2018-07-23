using Data.Infrastructure;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    class ItemMasterInventoryRepository : RepositoryBase<ItemMasterInventory>, IItemMasterInventoryRepository
    {
        //xu ly cai rieng bang nao thi dung repository nay
        public ItemMasterInventoryRepository(IDbFactory dbFactory) : base(dbFactory) { }

        //public int GetByDayTime(int day, int time)
        //{
            //return 0;
            //return DbContext.Schedules.Where(s => s.Day == day && s.Time == time).Select(s => s.Id).FirstOrDefault();

        //}
    }

    public interface IItemMasterInventoryRepository : IRepository<ItemMasterInventory>
    {
        //int GetByDayTime(int day, int time);

    }
}
