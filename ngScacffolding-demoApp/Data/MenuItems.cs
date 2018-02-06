using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ngScaffolding.ConfigHelpers;
using ngScaffolding.database.Models;
using ngScaffolding.Data;
using ngScaffolding.Models;

namespace ngScacffolding.demoApp.Data
{
    public class MenuItems
    {
        public static void Setup(ngScaffoldingContext demoCtx)
        {
            // Demo Folder
          var demoFolder = MenuHelper.AddMenu(demoCtx, new MenuItem
            {
                Badge="folder",
                Name = "Demo.Folder",
                Label = "Demo Folder",
                Type = MenuItem.Type_Folder
            });

            var gridView1 = MenuHelper.AddMenu(demoCtx, new MenuItem
            {
                Badge = "grid",
                Name = "Demo.GridView",
                Label = "Demo GridView",
                Type = MenuItem.Type_GridView,
                ParentMenuItemId = demoFolder.Id,
                MenuItemDetail = new GridViewDetailModel()
                {
                    PageSize = 50
                }
            });
        }
    }
}
