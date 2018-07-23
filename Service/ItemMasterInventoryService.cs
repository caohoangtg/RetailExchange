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
    public interface IItemMasterInventoryService
    {
        IEnumerable<ItemMasterInventory> GetItemMasterInventorys();
        ItemMasterInventory GetItemMasterInventory(int id);
        void CreateItemMasterInventory(ItemMasterInventory ItemMasterInventory);
        void SaveItemMasterInventory();
        void DeleteItemMasterInventory(int id);

    }

    public class ItemMasterInventoryService : IItemMasterInventoryService
    {
        private readonly IItemMasterInventoryRepository itemMasterInventoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public ItemMasterInventoryService(IItemMasterInventoryRepository itemMasterInventoryRepository, IUnitOfWork unitOfWork)
        {
            this.itemMasterInventoryRepository = itemMasterInventoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateItemMasterInventory(ItemMasterInventory ItemMasterInventory)
        {
            itemMasterInventoryRepository.Add(ItemMasterInventory);
        }

        public ItemMasterInventory GetItemMasterInventory(int id)
        {
            var ItemMasterInventory = itemMasterInventoryRepository.GetById(id);
            return ItemMasterInventory;
        }

        public IEnumerable<ItemMasterInventory> GetItemMasterInventorys()
        {
            var ItemMasterInventorys = itemMasterInventoryRepository.GetAll();
            return ItemMasterInventorys;
        }

        public void SaveItemMasterInventory()
        {
            unitOfWork.Commit();
        }
        public void DeleteItemMasterInventory(int id)
        {
            var itemMasterInventory = itemMasterInventoryRepository.GetById(id);
            itemMasterInventoryRepository.Delete(itemMasterInventory);
        }
        public DbSet<ItemMasterInventory> GetTable()
        {
            var ItemMasterInventorys = itemMasterInventoryRepository.GetTable();
            return ItemMasterInventorys;
        }
    }
}
