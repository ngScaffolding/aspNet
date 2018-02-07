using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ngScaffolding.ConfigHelpers;
using ngScaffolding.database.Models;
using ngScaffolding.Data;
using ngScaffolding.Models;
using ngScaffolding.Models.DataSourceModels;

namespace ngScacffolding.demoApp.Data
{
    public class MenuItems
    {
        public static void Setup(ngScaffoldingContext demoCtx)
        {
            // Demo Folder
            var demoFolder = MenuHelper.AddMenu(demoCtx, new MenuItem
            {
                Badge = "folder",
                Name = "Demo.Folder",
                Label = "Demo Folder",
                Roles = "User",
                Type = MenuItem.Type_Folder
            });

            var gridView1 = MenuHelper.AddMenu(demoCtx, new MenuItem
            {
                Roles = "User",
                Badge = "grid",
                Name = "Demo.Countries.Admin",
                Label = "Countries Admin",
                Type = MenuItem.Type_GridView,
                ParentMenuItemId = demoFolder.Id,
                MenuItemDetail = new GridViewDetailModel()
                {
                    Title = "Countries",
                    Columns = new List<ColumnModel>()
                    {
                        new ColumnModel() { Field = "Id" },
                        new ColumnModel() {Field = "ContinentName"},
                        new ColumnModel() {Field = "Name"}
                    },
                    SelectCommand = new BaseDataSource()
                    {
                        Connection = "demoDatabase",
                        IsAudit = true,
                        SqlCommand = "SELECT [Id],[ContinentId],[ContinentName],[Name] FROM [dbo].[Countries] ORDER by ContinentName, Name"
                    },
                    Filters = new List<InputDetail>()
                    {
                        new InputDetailDropdown(){Name = "Continent", Label = "Continent", Type = InputDetail.Type_Select,Datasource = "Continents"}
                    }
                },


            });
        }
    }
}
