﻿using AutoMapper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x => {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDoMainMappingProfile>();
                
            });
        }
    }
}