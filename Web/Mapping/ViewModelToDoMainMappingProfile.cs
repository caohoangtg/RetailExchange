using AutoMapper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.ViewModels;

namespace Web.Mapping
{
    public class ViewModelToDoMainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
        public ViewModelToDoMainMappingProfile()
        {
            CreateMap<ItemMasterViewModel, ItemMaster>();
            CreateMap<ItemMasterInventoryViewModel, ItemMasterInventory>();
        }
    }
}