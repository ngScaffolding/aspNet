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
                icon = "folder",
                Name = "Demo.Folder",
                label = "Demo Folder",
                Roles = "User",
                type = MenuItem.Type_Folder
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

            var dsPieChart = new DataSource
            {
                Type = DataSource.TypesSql,
                Name = "Countries.Pie.Chart",
                JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                {
                    Connection = "demoDatabase",
                    IsAudit = true,
                    SqlCommand = "SELECT ContinentName, Count(*) as [Total] FROM[dbo].[Countries] group by ContinentName"
                })

            };
            demoCtx.DataSources.Add(dsPieChart);

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
                    SqlCommand = "UPDATE [Continents] Set [Name] = ''@@Name'' WHERE [Id] = @@Id"
                })
            };
            demoCtx.DataSources.Add(dsUpdContinent);

            demoCtx.SaveChanges();

            var gridView1 = MenuHelper.AddMenu(demoCtx, new MenuItem
            {
                Roles = "User",
                icon = "grid",
                Name = "Demo.Countries.Admin",
                label = "Countries Admin",
                type = MenuItem.Type_GridView,
                routerLink = "datagrid,Demo.Countries.Admin",
                parentMenuItemId = demoFolder.Id,
                jsonSerialized = JsonConvert.SerializeObject(new GridViewDetailModel()
                {
                    title = "Countries Administration",
                    columns = new List<ColumnModel>()
                    {
                        new ColumnModel() { Field = "Id" },
                        new ColumnModel() {Field = "ContinentName"},
                        new ColumnModel() {Field = "Name"}
                    },
                    selectDataSourceId = dataSource1.Id,
                    filters = new InputBuilderDefinition()
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
                icon = "brush",
                Name = "Demo.Continents.Admin",
                label = "Continents Admin",
                type = MenuItem.Type_GridView,
                routerLink = "datagrid,Demo.Continents.Admin",
                parentMenuItemId = demoFolder.Id,
                jsonSerialized = JsonConvert.SerializeObject(new GridViewDetailModel()
                {
                    title = "Continents Administration",

                    columns = new List<ColumnModel>()
                    {
                        new ColumnModel() { Field = "Id" },
                        new ColumnModel() {Field = "ContinentName"},
                        new ColumnModel() {Field = "Name"}
                    },
                    selectDataSourceId = dataSource2.Id,
                    filters = new InputBuilderDefinition()
                    {
                        inputDetails = new List<InputDetail>()
                        {
                            new InputDetailDropdown(){name = "Continent", label = "Continent", type = InputDetail.Type_Select,referenceValueName = "Continents"}
                        }
                    },
                    isActionColumnSplitButton = false,
                    actions = new List<ActionModel>
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

            var chart1 = MenuHelper.AddMenu(demoCtx, new MenuItem
            {
                Roles = "User",
                icon = "brush",
                Name = "Demo.Continents.PieGraph",
                label = "Continents Graph",
                type = MenuItem.Type_GridView,
                routerLink = "chart,Demo.Continents.PieGraph",
                parentMenuItemId = demoFolder.Id,
                jsonSerialized = JsonConvert.SerializeObject(new ChartDetailModel()
                {
                    title = "Countries by Continent",
                    chartOptions = new Highsoft.Web.Mvc.Charts.Chart { },
                    dataSourceId = dsPieChart.Id
                })
            });
        }
    }
}