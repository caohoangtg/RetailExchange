using AutoMapper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.ViewModels;

namespace Web.Mapping
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<ItemMaster, ItemMasterViewModel>();
            CreateMap<ItemMasterInventory, ItemMasterInventoryViewModel>();
            CreateMap<ItemMaster, ItemMaster>();
        }
    }
}