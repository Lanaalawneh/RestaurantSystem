﻿using Microsoft.AspNetCore.Mvc;
using Restorent.Models.Repositories;
using Restorent.Models;

namespace Restorent.Areas.Admin.Components
{
    public class MasterMenuComponent : ViewComponent
    {


        public IRepository<MasterMenu> MasterMenu { get; }

        public MasterMenuComponent(IRepository<MasterMenu> _MasterMenu)
        {
            MasterMenu = _MasterMenu;
        }



        public IViewComponentResult Invoke()
        {
            var data = MasterMenu.View();
            return View(data);
        }



    }
}
