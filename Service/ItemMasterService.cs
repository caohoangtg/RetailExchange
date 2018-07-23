using Data.Infrastructure;
using Data.Repositories;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IItemMasterService
    {
        IEnumerable<ItemMaster> GetItemMasters();
        ItemMaster GetItemMaster(int id);
        void CreateItemMaster(ItemMaster ItemMaster);
        void EditItemMaster(ItemMaster ItemMaster);
        void SaveItemMaster();
        void DeleteItemMaster(int id);
        DbSet<ItemMaster> GetTable();
    }

    public class ItemMasterService : IItemMasterService
    {
        private readonly IItemMasterRepository itemMasterRepository;
        private readonly IUnitOfWork unitOfWork;

        public ItemMasterService(IItemMasterRepository itemMasterRepository, IUnitOfWork unitOfWork)
        {
            this.itemMasterRepository = itemMasterRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateItemMaster(ItemMaster ItemMaster)
        {
            itemMasterRepository.Add(ItemMaster);
        }

        public void EditItemMaster(ItemMaster ItemMaster)
        {
            itemMasterRepository.Edit(ItemMaster);
        }

        public ItemMaster GetItemMaster(int id)
        {
            var itemMaster = itemMasterRepository.GetById(id);
            return itemMaster;
        }

        public DbSet<ItemMaster> GetTable()
        {
            var itemMasters = itemMasterRepository.GetTable();
            return itemMasters;
        }
        public IEnumerable<ItemMaster> GetItemMasters()
        {
            var itemMasters = itemMasterRepository.GetAll();
            return itemMasters;
        }

        public void SaveItemMaster()
        {
            unitOfWork.Commit();
        }
        public void DeleteItemMaster(int id)
        {
            var itemMaster = itemMasterRepository.GetById(id);
            itemMasterRepository.Delete(itemMaster);
        }
    }

}
