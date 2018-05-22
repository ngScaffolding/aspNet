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


            var dsSelectCountries = new DataSource()
            {
                Type = DataSource.TypesSql,
                Name = "Countries.Select",
                JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                {
                    Connection = "demoDatabase",
                    IsAudit = true,
                    SqlCommand = @"IF ''@@ContinentId'' Like ''@@%''
                            SELECT Countries.Id, Countries.Name,Countries.ContinentId, Continents.Name as ContinentName FROM Countries 
								INNER JOIN Continents on Continents.Id = Countries.ContinentId ORDER by ContinentName, Countries.Name
                                ELSE
                            SELECT Countries.Id, Countries.Name,Countries.ContinentId, Continents.Name as ContinentName FROM Countries 
								INNER JOIN Continents on Continents.Id = Countries.ContinentId where Continents.Id = ''@@ContinentId''  ORDER by ContinentName, Countries.Name"
                })
            };
            demoCtx.DataSources.Add(dsSelectCountries);

            var dsAddCountry = new DataSource
            {
                Type = DataSource.TypesSql,
                Name = "Countries.Add.New",
                JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                {
                    Connection = "demoDatabase",
                    IsAudit = true,
                    SqlCommand = "INSERT INTO Countries (Name, ContinentId) VALUES (''@@Name'',@@ContinentId)"
                })
            };
            demoCtx.DataSources.Add(dsAddCountry);

            var dsAddContinent = new DataSource
            {
                Type = DataSource.TypesSql,
                Name = "Continents.Add.New",
                JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                {
                    Connection = "demoDatabase",
                    IsAudit = true,
                    SqlCommand = "INSERT INTO Continents (Name) VALUES (''@@Name'')"
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
                    SqlCommand = "SELECT Continents.ContinentName, Count(*) as Total FROM Countries INNER JOIN Continents on Continents.Id = Countries.ContinentId group by Continents.ContinentName"
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
                    SqlCommand = "DELETE FROM Continents WHERE Id = ''@@Id''"
                })
            };
            demoCtx.DataSources.Add(dsDelContinent);

            var dsUpdCountry = new DataSource
                {
                    Type = DataSource.TypesSql,
                    Name = "Countries.Update",
                    JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                    {
                        Connection = "demoDatabase",
                        IsAudit = true,
                        SqlCommand = "UPDATE Countries Set Name = ''@@Name'', ContinentId = @@ContinentId WHERE Id = @@Id"
                    })
                };
            demoCtx.DataSources.Add(dsUpdCountry);

            var dsUpdContinent = new DataSource
            {
                Type = DataSource.TypesSql,
                Name = "Continents.Update",
                JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                {
                    Connection = "demoDatabase",
                    IsAudit = true,
                    SqlCommand = "UPDATE Continents Set Name = ''@@Name'' WHERE Id = @@Id"
                })
            };
            demoCtx.DataSources.Add(dsUpdContinent);

            demoCtx.SaveChanges();

            var gridCountries = MenuHelper.AddMenu(demoCtx, new MenuItem
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
                    selectDataSourceId = dsSelectCountries.Id,
                    filters = new InputBuilderDefinition()
                    {
                        inputDetails = new List<InputDetail>()
                        {
                            new InputDetailDropdown(){name = "ContinentId", label = "Continent", referenceValueName = "Continents"}
                        }
                    },
                    actions = new List<ActionModel>
                    {
                        new ActionModel
                        {
                            columnButton = true,
                            title="Edit Country",
                            icon="ui-icon-add", color="green", type = ActionTypes.SqlCommand,
                            dataSourceId = dsUpdCountry.Id,
                            successMessage = "Country Updated",
                            successToast = true,
                            errorMessage = "Country not updated. Try Again Later.",
                            inputBuilderDefinition = new InputBuilderDefinition(){
                                title = "Country Details",
                                okButtonText = "Update Country",
                                orientation = "horizontal",
                                horizontalColumnCount = 1,
                                inputDetails = new List<InputDetail>
                                {
                                    new InputDetailTextBox{name = "Name", validateRequired = "Name is required",label="Country Name" , placeholder="Country Name"},
                                    new InputDetailDropdown{name = "ContinentId", validateRequired = "Continent is required", label = "Continent", referenceValueName = "Continents"}
                                }
                            }
                        },
                        new ActionModel
                        {
                            title = "Add Country", icon="ui-icon-add", color="green", type = ActionTypes.SqlCommand, dataSourceId = dsAddCountry.Id,
                            successMessage = "Country Saved",
                            successToast = true,
                            errorMessage = "Country not saved. Try Again Later.",
                            inputBuilderDefinition = new InputBuilderDefinition(){
                                title = "New Country Details",
                                okButtonText = "Save Country",
                                orientation = "horizontal",
                                horizontalColumnCount = 1,
                                inputDetails = new List<InputDetail>
                                {
                                    new InputDetailTextBox{name = "Name", validateRequired = "Name is required",label="Country Name" , placeholder="Country Name"},
                                    new InputDetailDropdown{name = "ContinentId", validateRequired = "Continent is required", label = "Continent", referenceValueName = "Continents"}
                                }
                            }
                        },
                         new ActionModel
                        {
                            title = "Delete Country", icon="ui-icon-minus", color="red", type = ActionTypes.SqlCommand, dataSourceId = dsDelContinent.Id,
                            successMessage = "Country Deleted",
                            successToast = true,
                            errorMessage = "Country not saved. Try Again Later.",
                            multipleTarget = true,
                            selectionRequired = true,
                            confirmationMessage = "Delete Country, Are you sure?"
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
                    SqlCommand = "SELECT Id, Name FROM Continents ORDER by Name"
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

            var dashboard1 = MenuHelper.AddMenu(demoCtx, new MenuItem
            {
                Roles = "User",
                icon = "brush",
                Name = "Demo.Continents.Dashboard",
                label = "Continents Dashboard",
                type = MenuItem.Type_Dashboard,
                routerLink = "dashboard,Demo.Continents.Dashboard",
                parentMenuItemId = demoFolder.Id,
                jsonSerialized = JsonConvert.SerializeObject(new DashboardModel()
                {
                    title = "Countries by Continent",
                    widgets = new List<WidgetModel> {
                        new WidgetModel{cols= 2, rows= 1, y= 0, x= 0 ,title="Widget One" },
                        new WidgetModel{cols= 4, rows= 6, y= 0, x= 4, title="Widget Big" }
                    }
                })
            });
        }
    }
}