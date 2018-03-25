using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ngScaffolding.ConfigHelpers;
using ngScaffolding.database.Models;
using ngScaffolding.Data;
using ngScaffolding.Models;
using ngScaffolding.Models.DataSourceModels;
using Newtonsoft.Json;

namespace ngScacffolding.demoApp.Data
{
    public class MenuItems
    {
        public static void Setup(ngScaffoldingContext demoCtx)
        {
            // Demo Folder
            var demoFolder = MenuHelper.AddMenu(demoCtx, new MenuItem
            {
                Icon = "folder",
                Name = "Demo.Folder",
                Label = "Demo Folder",
                Roles = "User",
                Type = MenuItem.Type_Folder
            });

            
            var dataSource1 = new DataSource()
            {
                Type = DataSource.TypesSql,
                JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                {
                    Connection = "demoDatabase",
                    IsAudit = true,
                    SqlCommand = "SELECT [Id],[ContinentId],[ContinentName],[Name] FROM [dbo].[Countries] ORDER by ContinentName, Name"
                })
            };
            demoCtx.DataSources.Add(dataSource1);
            demoCtx.SaveChanges();

            var gridView1 = MenuHelper.AddMenu(demoCtx, new MenuItem
            {
                Roles = "User",
                Icon = "grid",
                Name = "Demo.Countries.Admin",
                Label = "Countries Admin",
                Type = MenuItem.Type_GridView,
                RouterLink = "datagrid,Demo.Countries.Admin",
                ParentMenuItemId = demoFolder.Id,
                JsonSerialized = JsonConvert.SerializeObject( new GridViewDetailModel()
                {
                    Title = "Countries",
                    Columns = new List<ColumnModel>()
                    {
                        new ColumnModel() { Field = "Id" },
                        new ColumnModel() {Field = "ContinentName"},
                        new ColumnModel() {Field = "Name"}
                    },
                    SelectDataSourceId = dataSource1.Id,
                    Filters = new InputBuilderDefinition()
                    {
                        InputDetails = new List<InputDetail>()
                        {
                            new InputDetailDropdown(){name = "Continent", label = "Continent", type = InputDetail.Type_Select, referenceValueName = "Continents"}
                        }
                    }
                })
            });

            var dataSource2 = new DataSource()
            {
                Type = DataSource.TypesSql,
                JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                {
                    Connection = "demoDatabase",
                    IsAudit = true,
                    SqlCommand = "SELECT [Id],[ContinentId],[ContinentName],[Name] FROM [dbo].[Continents] ORDER by ContinentName, Name"
                })
            };
            demoCtx.DataSources.Add(dataSource2);
            demoCtx.SaveChanges();

            var gridView2 = MenuHelper.AddMenu(demoCtx, new MenuItem
            {
                Roles = "User",
                Icon = "grid",
                Name = "Demo.Continents.Admin",
                Label = "Continents Admin",
                Type = MenuItem.Type_GridView,
                RouterLink = "datagrid,Demo.Continents.Admin",
                ParentMenuItemId = demoFolder.Id,
                JsonSerialized = JsonConvert.SerializeObject( new GridViewDetailModel()
                {
                    Title = "Continents",
                    Columns = new List<ColumnModel>()
                    {
                        new ColumnModel() { Field = "Id" },
                        new ColumnModel() {Field = "ContinentName"},
                        new ColumnModel() {Field = "Name"}
                    },
                    SelectDataSourceId = dataSource2.Id,
                    Filters = new InputBuilderDefinition()
                    {
                        InputDetails = new List<InputDetail>()
                        {
                            new InputDetailDropdown(){name = "Continent", label = "Continent", type = InputDetail.Type_Select,referenceValueName = "Continents"}
                        }
                    }
                })
            });
        }
    }
}