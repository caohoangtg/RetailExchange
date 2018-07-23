using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Model
{
    public class ItemMaster
    {
        public int ItemMasterId { get; set; }
        public int Pack { get; set; }
        public string Description { get; set; }
        public string ImageData { get; set; }
        public bool HazardousMaterial { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; }
        public float UnitPrice { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }
        public float Height { get; set; }
        public bool IsPrePack { get; set; }
        public string PrePackStyte { get; set; }
        public String CostCenterCode { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public virtual IEnumerable<ItemMasterInventory> ItemMasterInventorys { get; set; }
    }
}
