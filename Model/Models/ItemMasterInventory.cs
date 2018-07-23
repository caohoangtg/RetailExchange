using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ItemMasterInventory
    {
        public int ItemMasterInventoryId { get; set; }
        public int Size { get; set; }
        public int QtyOnHand { get; set; }
        public int QtyAllocated { get; set; }
        public int ItemMasterId { get; set; }
        public virtual ItemMaster ItemMaster { get; set; }
    }
}
