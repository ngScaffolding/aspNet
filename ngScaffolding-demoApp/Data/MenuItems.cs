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
using static ngScaffolding.Models.ActionModel;

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
                Name = "Countries.Select",
                JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                {
                    Connection = "demoDatabase",
                    IsAudit = true,
                    SqlCommand = "SELECT [Id], [Name], [ContinentName] FROM [dbo].[Countries] where ContinentName Like ''%@@Continent%''  ORDER by ContinentName, Name"
                })
            };
            demoCtx.DataSources.Add(dataSource1);

            var dsAddContinent = new DataSource
            {
                Type = DataSource.TypesSql,
                Name = "Continents.Add.New",
                JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                {
                    Connection = "demoDatabase",
                    IsAudit = true,
                    SqlCommand = "INSERT INTO [Continents] ([Name]) VALUES (''@@Name'')"
                })
            };
            demoCtx.DataSources.Add(dsAddContinent);
            var dsDelContinent = new DataSource
            {
                Type = DataSource.TypesSql,
                Name = "Continents.Delete",
                JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                {
                    Connection = "demoDatabase",
                    IsAudit = true,
                    SqlCommand = "DELETE FROM [Continents] WHERE [Id] = ''@@Id''"
                })
            };
            demoCtx.DataSources.Add(dsDelContinent);

            var dsUpdContinent = new DataSource
            {
                Type = DataSource.TypesSql,
                Name = "Continents.Update",
                JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                {
                    Connection = "demoDatabase",
                    IsAudit = true,
                    SqlCommand = "UPDATE FROM [Continents] Set [Name] = ''@@Name'' WHERE [Id] = @@Id"
                })
            };
            demoCtx.DataSources.Add(dsUpdContinent);


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
                JsonSerialized = JsonConvert.SerializeObject(new GridViewDetailModel()
                {
                    Title = "Countries Administration",
                    Columns = new List<ColumnModel>()
                    {
                        new ColumnModel() { Field = "Id" },
                        new ColumnModel() {Field = "ContinentName"},
                        new ColumnModel() {Field = "Name"}
                    },
                    SelectDataSourceId = dataSource1.Id,
                    Filters = new InputBuilderDefinition()
                    {
                        inputDetails = new List<InputDetail>()
                        {
                            new InputDetailDropdown(){name = "Continent", label = "Continent", type = InputDetail.Type_Select, referenceValueName = "Continents"}
                        }
                    }

                })
            });

            var dataSource2 = new DataSource()
            {
                Type = DataSource.TypesSql,
                Name = "Continents.Select",
                JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                {
                    Connection = "demoDatabase",
                    IsAudit = true,
                    SqlCommand = "SELECT [Id], [Name] FROM [dbo].[Continents] ORDER by Name"
                })
            };
            demoCtx.DataSources.Add(dataSource2);
            demoCtx.SaveChanges();

            var gridView2 = MenuHelper.AddMenu(demoCtx, new MenuItem
            {
                Roles = "User",
                Icon = "brush",
                Name = "Demo.Continents.Admin",
                Label = "Continents Admin",
                Type = MenuItem.Type_GridView,
                RouterLink = "datagrid,Demo.Continents.Admin",
                ParentMenuItemId = demoFolder.Id,
                JsonSerialized = JsonConvert.SerializeObject(new GridViewDetailModel()
                {
                    Title = "Continents Administration",

                    Columns = new List<ColumnModel>()
                    {
                        new ColumnModel() { Field = "Id" },
                        new ColumnModel() {Field = "ContinentName"},
                        new ColumnModel() {Field = "Name"}
                    },
                    SelectDataSourceId = dataSource2.Id,
                    Filters = new InputBuilderDefinition()
                    {
                        inputDetails = new List<InputDetail>()
                        {
                            new InputDetailDropdown(){name = "Continent", label = "Continent", type = InputDetail.Type_Select,referenceValueName = "Continents"}
                        }
                    },
                    Actions = new List<ActionModel>
                    {
                        new ActionModel
                        {
                            columnButton = true,
                            title="Edit Continent",
                            icon="ui-icon-add", color="green", type = ActionTypes.SqlCommand, dataSourceId = dsUpdContinent.Id,
                            successMessage = "Continent Updated",
                            successToast = true,
                            errorMessage = "Continent not updated. Try Again Later.",
                            inputBuilderDefinition = new InputBuilderDefinition(){
                                title = "Continent Details",
                                okButtonText = "Update Continent",
                                orientation = "horizontal",
                                horizontalColumnCount = 1,
                                inputDetails = new List<InputDetail>
                                {
                                    new InputDetailTextBox{name = "Name", validateRequired = "Name is required",label="Continent Name" , placeholder="Continent Name"}
                                }
                            }
                        },
                        new ActionModel
                        {
                            title = "Add Continent", icon="ui-icon-add", color="green", type = ActionTypes.SqlCommand, dataSourceId = dsAddContinent.Id,
                            successMessage = "Continent Saved",
                            successToast = true,
                            errorMessage = "Continent not saved. Try Again Later.",
                            inputBuilderDefinition = new InputBuilderDefinition(){
                                title = "New Continent Details",
                                okButtonText = "Save Continent",
                                orientation = "horizontal",
                                horizontalColumnCount = 1,
                                inputDetails = new List<InputDetail>
                                {
                                    new InputDetailTextBox{name = "Name", validateRequired = "Name is required",label="Continent Name" , placeholder="Continent Name"}
                                }
                            }
                        },
                         new ActionModel
                        {
                            title = "Delete Continent", icon="ui-icon-minus", color="red", type = ActionTypes.SqlCommand, dataSourceId = dsDelContinent.Id,
                            successMessage = "Continent Deleted",
                            successToast = true,
                            errorMessage = "Continent not saved. Try Again Later.",
                            multipleTarget = true,
                            selectionRequired = true,
                            confirmationMessage = "Delete Continent, Are you sure?"
                        }
                    }
                })
            });
        }
    }
}