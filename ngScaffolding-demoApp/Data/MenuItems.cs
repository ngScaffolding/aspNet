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
                name = "Demo.Folder",
                label = "Demo Folder",
                roles = "User",
                type = MenuItem.Type_Folder
            });


            var dsSelectCountries = new DataSource()
            {
                name = "Countries.Select",
                JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                {
                    connection = "demoDatabase",
                    isAudit = true,
                    sqlCommand = @"IF ''@@ContinentId'' Like ''@@%''
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
                name = "Countries.Add.New",
                JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                {
                    connection = "demoDatabase",
                    isAudit = true,
                    sqlCommand = "INSERT INTO Countries (Name, ContinentId) VALUES (''@@Name'',@@ContinentId)"
                })
            };
            demoCtx.DataSources.Add(dsAddCountry);

            var dsAddContinent = new DataSource
            {
                name = "Continents.Add.New",
                JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                {
                    connection = "demoDatabase",
                    isAudit = true,
                    sqlCommand = "INSERT INTO Continents (Name) VALUES (''@@Name'')"
                })
            };
            demoCtx.DataSources.Add(dsAddContinent);

            var dsCountires = new DataSource
            {
                name = "Countries.Pie.Chart",
                JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                {
                    connection = "demoDatabase",
                    isAudit = true,
                    sqlCommand = @"SELECT Continents.Name, COUNT(Countries.Id) as Countries, LEN(Continents.Name) * 2 as Characters
                                    FROM Continents INNER JOIN Countries ON Continents.Id = Countries.ContinentId GROUP by Continents.Name"
                })

            };
            demoCtx.DataSources.Add(dsCountires);

            var dsDelContinent = new DataSource
            {
                name = "Continents.Delete",
                JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                {
                    connection = "demoDatabase",
                    isAudit = true,
                    sqlCommand = "DELETE FROM Continents WHERE Id = ''@@Id''"
                })
            };
            demoCtx.DataSources.Add(dsDelContinent);

            var dsUpdCountry = new DataSource
            {
                name = "Countries.Update",
                JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                {
                    connection = "demoDatabase",
                    isAudit = true,
                    sqlCommand = "UPDATE Countries Set Name = ''@@Name'', ContinentId = @@ContinentId WHERE Id = @@Id"
                })
            };
            demoCtx.DataSources.Add(dsUpdCountry);

            var dsUpdContinent = new DataSource
            {
                name = "Continents.Update",
                JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                {
                    connection = "demoDatabase",
                    isAudit = true,
                    sqlCommand = "UPDATE Continents Set Name = ''@@Name'' WHERE Id = @@Id"
                })
            };
            demoCtx.DataSources.Add(dsUpdContinent);

            demoCtx.SaveChanges();

            var gridCountries = MenuHelper.AddMenu(demoCtx, new MenuItem
            {
                roles = "User",
                icon = "flag",
                name = "Demo.Countries.Admin",
                label = "Countries Admin",
                type = MenuItem.Type_GridView,
                routerLink = "datagrid,Demo.Countries.Admin",
                parentMenuItemId = demoFolder.id,
                jsonSerialized = JsonConvert.SerializeObject(new GridViewDetailModel()
                {
                    title = "Countries Administration",
                    columns = new List<ColumnModel>()
                    {
                        new ColumnModel() { Field = "Id" },
                        new ColumnModel() {Field = "ContinentName"},
                        new ColumnModel() {Field = "Name"}
                    },
                    selectDataSourceId = dsSelectCountries.id,
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
                            dataSourceId = dsUpdCountry.id,
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
                            title = "Add Country", icon="ui-icon-add", color="green", type = ActionTypes.SqlCommand, dataSourceId = dsAddCountry.id,
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
                            title = "Delete Country", icon="ui-icon-minus", color="red", type = ActionTypes.SqlCommand, dataSourceId = dsDelContinent.id,
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

            var apiContinentsSource = new DataSource
            {
                JsonContent = JsonConvert.SerializeObject(new RestApiDataSource
                {
                    serverName = "demoApi",
                    url = "/continents",
                    verb = "get",

                    isAudit = true,
                })
            };
            demoCtx.DataSources.Add(apiContinentsSource);
            demoCtx.SaveChanges();

            var dataSource2 = new DataSource()
            {
                name = "Continents.Select",
                JsonContent = JsonConvert.SerializeObject(new SqlDataSource
                {
                    connection = "demoDatabase",
                    isAudit = true,
                    sqlCommand = "SELECT Id, Name FROM Continents ORDER by Name"
                })
            };
            demoCtx.DataSources.Add(dataSource2);
            demoCtx.SaveChanges();

            var gridView2 = MenuHelper.AddMenu(demoCtx, new MenuItem
            {
                roles = "User",
                icon = "brush",
                name = "Demo.Continents.Admin",
                label = "Continents Admin",
                type = MenuItem.Type_GridView,
                routerLink = "datagrid,Demo.Continents.Admin",
                parentMenuItemId = demoFolder.id,
                jsonSerialized = JsonConvert.SerializeObject(new GridViewDetailModel()
                {
                    title = "Continents Administration",

                    columns = new List<ColumnModel>()
                    {
                        //new ColumnModel() { Field = "Id" },
                        //new ColumnModel() {Field = "ContinentName"},
                        new ColumnModel() {Field = "name", HeaderName= "Continent Name"}
                    },
                    selectDataSourceId = apiContinentsSource.id,

                    isActionColumnSplitButton = false,
                    actions = new List<ActionModel>
                    {
                        new ActionModel
                        {
                            columnButton = true,
                            title="Edit Continent",
                            icon="ui-icon-add", color="green", type = ActionTypes.SqlCommand, dataSourceId = dsUpdContinent.id,
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
                            title = "Add Continent", icon="ui-icon-add", color="green", type = ActionTypes.SqlCommand, dataSourceId = dsAddContinent.id,
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
                            title = "Delete Continent", icon="ui-icon-minus", color="red", type = ActionTypes.SqlCommand, dataSourceId = dsDelContinent.id,
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
                roles = "User",
                icon = "show-chart",
                name = "Demo.Continents.PieGraph",
                label = "Continents Graph",
                type = MenuItem.Type_GridView,
                routerLink = "chart,Demo.Continents.PieGraph",
                parentMenuItemId = demoFolder.id,
                jsonSerialized = JsonConvert.SerializeObject(new ChartDetailModel()
                {
                    title = "Countries by Continent",
                    xAxisName = "Name",
                    seriesNames = new string[] { "Countries", "Characters" },
                    chartOptions = @"{
	                                    ""chart"": {
		                                    ""type"": ""bar""
	                                    },
	                                    ""title"": {
		                                    ""text"": ""Basic drilldown Man""
	                                    },
	                                    ""legend"": {
		                                    ""enabled"": false
	                                    },

	                                    ""plotOptions"": {
		                                    ""series"": {
			                                    ""dataLabels"": {
				                                    ""enabled"": true
			                                    }
		                                    }
	                                    }
                                    }",
                    dataSourceId = dsCountires.id
                })
            });

            var dashboard1 = MenuHelper.AddMenu(demoCtx, new MenuItem
            {
                roles = "User",
                icon = "dashboard",
                name = "Demo.Continents.Dashboard",
                label = "Continents Dashboard",
                type = MenuItem.Type_Dashboard,
                routerLink = "dashboard,Demo.Continents.Dashboard",
                parentMenuItemId = demoFolder.id,
                jsonSerialized = JsonConvert.SerializeObject(new DashboardModel()
                {
                    title = "Countries by Continent",
                    widgets = new List<WidgetModel> {
                        new WidgetModel{cols= 3, rows= 4, y= 0, x= 0 ,chartDetail = new ChartDetailModel{ title = "Countries by Continent",
                    xAxisName = "Name",
                    seriesNames = new string[] { "Countries", "Characters" },
                    chartOptions = @"{
	                                    ""chart"": {
		                                    ""type"": ""bar""
	                                    },
	                                    ""title"": {
		                                    ""text"": ""Basic drilldown Man""
	                                    },
	                                    ""legend"": {
		                                    ""enabled"": false
	                                    },

	                                    ""plotOptions"": {
		                                    ""series"": {
			                                    ""dataLabels"": {
				                                    ""enabled"": true
			                                    }
		                                    }
	                                    }
                                    }",
                    dataSourceId = dsCountires.id }
                        },
                        new WidgetModel{cols= 4, rows= 6, y= 0, x= 4, gridViewDetail = new GridViewDetailModel
                {
                    title = "Continents Administration",

                    columns = new List<ColumnModel>()
                    {
                        new ColumnModel() {Field = "name", HeaderName= "Continent Name"}
                    },
                    selectDataSourceId = apiContinentsSource.id}
                        }
                    }
                })
            });
        }
    }
}