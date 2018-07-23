using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ViewModels
{
    public class ItemMasterViewModel
    {
        public int ItemMasterId { get; set; }
        public int Pack { get; set; }
        public string Description { get; set; }
        public string ImageData { get; set; }
        public bool HazardousMaterial { get; set; }
        public DateTime ExpirationDate { get; set; }
        public float UnitPrice { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }
        public float Height { get; set; }
        public bool IsPrePack { get; set; }
        public string PrePackStyte { get; set; }
        public String CostCenterCode { get; set; }
        public virtual IEnumerable<ItemMasterInventoryViewModel> ItemMasterInventoryViewModels { get; set; }
    }
}