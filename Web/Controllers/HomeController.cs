using AutoMapper;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemMasterService itemMastersService;
        private readonly IItemMasterInventoryService itemMasterInventoryService;
        public HomeController(IItemMasterService itemMastersService, IItemMasterInventoryService itemMasterInventoryService)
        {
            this.itemMastersService = itemMastersService;
            this.itemMasterInventoryService = itemMasterInventoryService;
        }
        public ActionResult Index()
        {
            ViewBag.ItemMasterId = new SelectList(itemMastersService.GetTable(), "ItemMasterId", "ItemMasterId");
            ViewBag.PrePackStyte = new SelectList(itemMastersService.GetTable(), "PrePackStyte", "PrePackStyte");
            if (Request.IsAjaxRequest())
                return PartialView("_Index1");
            return View();
        }
        public ActionResult _Index1()
        {
            if (Request.IsAjaxRequest())
                return PartialView();
            return View();
        }
        public ActionResult _Index2()
        {
            IEnumerable<ItemMasterInventoryViewModel> viewItemMasterInventory;
            IEnumerable<ItemMasterInventory> itemMasterInventory;
            itemMasterInventory = itemMasterInventoryService.GetItemMasterInventorys().ToList();
            viewItemMasterInventory = Mapper.Map<IEnumerable<ItemMasterInventory>, IEnumerable<ItemMasterInventoryViewModel>>(itemMasterInventory);
            ViewBag.ViewInventory = viewItemMasterInventory;
            if (Request.IsAjaxRequest())
                return PartialView();
            return View();
        }
        public JsonResult CreateId()
        {
            IEnumerable<ItemMasterViewModel> viewItemMaster;
            IEnumerable<ItemMaster> itemMaster;
            itemMaster = itemMastersService.GetItemMasters().ToList();
            viewItemMaster = Mapper.Map<IEnumerable<ItemMaster>, IEnumerable<ItemMasterViewModel>>(itemMaster);
            var newId = viewItemMaster.Select(i => i.ItemMasterId).LastOrDefault() + 1;
            return Json(newId, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ChangeItem(int id)
        {
            //int HI = Convert.ToInt16(id);
            ItemMaster itemMaster = itemMastersService.GetItemMaster(id);
            if (itemMaster == null)
            {
                return null;
            }
            return Json(itemMaster, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public void Edit([Bind(Include = "ItemMasterId,Pack,Description,ImageData,HazardousMaterial,ExpirationDate,UnitPrice,Width,Length,Height,IsPrePack,PrePackStyte,CostCenterCode")] ItemMasterViewModel model)
        {
            ItemMaster master = Mapper.Map<ItemMasterViewModel, ItemMaster>(model);
            ItemMaster itemMaster = itemMastersService.GetItemMaster(model.ItemMasterId);
            if (itemMaster == null)
            {
                itemMastersService.CreateItemMaster(master);
                itemMastersService.SaveItemMaster();
            }
            else if (ModelState.IsValid)
            {
                Mapper.Map(master, itemMaster);
                //itemMastersService.EditItemMaster(master);
                itemMastersService.SaveItemMaster();
            }
            return; 
        }
        [HttpPost]
        public void Upload([Bind(Include = "ItemMasterId,Pack,Description,ImageData,HazardousMaterial,ExpirationDate,UnitPrice,Width,Length,Height,IsPrePack,PrePackStyte,CostCenterCode,ImageFile")] ItemMaster model)
        {
            var file = model.ImageFile;
            ItemMaster itemMaster = itemMastersService.GetItemMaster(model.ItemMasterId);
            if (itemMaster == null)
            {
                file.SaveAs(Server.MapPath("~/Image/" + file.FileName));
                model.ImageData = file.FileName;
                itemMastersService.CreateItemMaster(model);
                itemMastersService.SaveItemMaster();
                
            }
            else if (file != null)
            {
                file.SaveAs(Server.MapPath("~/Image/" + file.FileName));
                if (model.ImageData != "default.png" && System.IO.File.Exists(Server.MapPath("~/Image/" + model.ImageData)))
                {
                    System.IO.File.Delete(Server.MapPath("~/Image/" + model.ImageData));
                }
                model.ImageData = file.FileName;
                //if (ModelState.IsValid)
                //{
                    Mapper.Map(model, itemMaster);
                    //itemMastersService.EditItemMaster(model);
                    itemMastersService.SaveItemMaster();
                //}
            }
            else
            {
                if (model.ImageData != "default.png" && System.IO.File.Exists(Server.MapPath("~/Image/" + model.ImageData)))
                {
                    System.IO.File.Delete(Server.MapPath("~/Image/" + model.ImageData));
                }
                model.ImageData = "default.png";
                //if (ModelState.IsValid)
                //{
                    Mapper.Map(model, itemMaster);
                    //itemMastersService.EditItemMaster(model);
                    itemMastersService.SaveItemMaster();
                //}
            }
            return;
        }
    }
}