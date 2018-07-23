using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ViewModels
{
    public class ItemMasterInventoryViewModel
    {
        public int ItemMasterInventoryId { get; set; }
        public int Size { get; set; }
        public int QtyOnHand { get; set; }
        public int QtyAllocated { get; set; }
        public int ItemMasterId { get; set; }
        public virtual ItemMasterViewModel ItemMaster { get; set; }
    }
}