using Newtonsoft.Json;
using ngScaffolding.ConfigHelpers;
using ngScaffolding.Data;
using ngScaffolding.database.Models;
using ngScaffolding.Models;
using ngScaffolding.Models.DataSourceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ngScaffolding.Models.ActionModel;

namespace ngScacffolding.demoApp.Data
{

    public class APIMenuItems
    {
        public static void Setup(ngScaffoldingContext demoCtx)
        {
            // Demo Folder
            var demoFolder = MenuHelper.AddMenu(demoCtx, new MenuItem
            {
                icon = "folder",
                name = "Demo.API.Folder",
                label = "Demo API Folder",
                roles = "User",
                type = MenuItem.Type_Folder
            });


            var dsSelectCountries = new DataSource()
            {
                name = "Countries.API.Select",
                JsonContent = JsonConvert.SerializeObject(new RestApiDataSource
                {
                    serverName = "demoDatabase",
                    verb = "get",
                    isAudit = true,
                    url= "/countries?continentid=@@continentid"
                })
            };
            demoCtx.DataSources.Add(dsSelectCountries);

            var dsAddCountry = new DataSource
            {
                name = "Countries.API.Add.New",
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
                name = "Continents.API.Add.New",
                JsonContent = JsonConvert.SerializeObject(new RestApiDataSource
                {
                    serverName = "demoDatabase",
                    verb = "post",
                    isAudit = true,
                    url = "/continents"
                })
            };
            demoCtx.DataSources.Add(dsAddContinent);

           var dsDelContinent = new DataSource
            {
                name = "Continents.API.Delete",
               JsonContent = JsonConvert.SerializeObject(new RestApiDataSource
               {
                   serverName = "demoDatabase",
                   verb = "delete",
                   isAudit = true,
                   url = "/continents/@@continentid"
               })
           };
            demoCtx.DataSources.Add(dsDelContinent);

            var dsUpdCountry = new DataSource
            {
                name = "Countries.API.Update",
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
                name = "Continents.API.Update",
                JsonContent = JsonConvert.SerializeObject(new RestApiDataSource
                {
                    serverName = "demoDatabase",
                    verb = "put",
                    isAudit = true,
                    url = "/continents/@@continentid"
                })
            };
            demoCtx.DataSources.Add(dsUpdContinent);

            demoCtx.SaveChanges();

            var gridCountries = MenuHelper.AddMenu(demoCtx, new MenuItem
            {
                roles = "User",
                icon = "flag",
                name = "Demo.Countries.API.Admin",
                label = "Countries Admin",
                type = MenuItem.Type_GridView,
                routerLink = "datagrid,Demo.Countries.API.Admin",
                parentMenuItemId = demoFolder.id,
                jsonSerialized = JsonConvert.SerializeObject(new GridViewDetailModel()
                {
                    title = "Countries Administration",
                    columns = new List<ColumnModel>()
                    {
                        new ColumnModel() { Field = "id", HeaderName="Id" },
                        new ColumnModel() {Field = "continentName", HeaderName ="Continent Name"},
                        new ColumnModel() {Field = "name", HeaderName = "Country Name"}
                    },
                    selectDataSourceName = dsSelectCountries.name,
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
                            dataSourceName = dsUpdCountry.name,
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
                            title = "Add Country", icon="ui-icon-add", color="green", type = ActionTypes.SqlCommand, dataSourceName = dsAddCountry.name,
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
                            title = "Delete Country", icon="ui-icon-minus", color="red", type = ActionTypes.SqlCommand, dataSourceName = dsDelContinent.name,
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
                name = "Continents.API.Select",
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
                name = "Demo.Continents.API.Admin",
                label = "Continents Admin",
                type = MenuItem.Type_GridView,
                routerLink = "datagrid,Demo.Continents.API.Admin",
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
                    selectDataSourceName = apiContinentsSource.name,

                    isActionColumnSplitButton = false,
                    actions = new List<ActionModel>
                    {
                        new ActionModel
                        {
                            columnButton = true,
                            title="Edit Continent",
                            icon="ui-icon-add", color="green", type = ActionTypes.SqlCommand, dataSourceName = dsUpdContinent.name,
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
                            title = "Add Continent", icon="ui-icon-add", color="green", type = ActionTypes.SqlCommand, dataSourceName = dsAddContinent.name,
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
                            title = "Delete Continent", icon="ui-icon-minus", color="red", type = ActionTypes.SqlCommand, dataSourceName = dsDelContinent.name,
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