using ngScaffolding.ConfigHelpers;
using ngScaffolding.Data;
using ngScaffolding.Models;
using ngScaffolding.Models.DataSourceModels;

namespace ngScacffolding.demoApp
{
    public class DataSourceSetup
    {
        public static void Setup(ngScaffoldingContext ctx)
        {
            DataSourceHelper.Add(ctx, new DataSource()
            {
                name = "Continents",
                DataSourceDetails = new SqlDataSource()
                {
                    connection = "demoDatabase",
                    sqlCommand = DropDownSourceHelper.IncludeNull("Continents", "Name", "Name", "Name"),
                    isAudit = true
                }
            });

            DataSourceHelper.Add(ctx, new DataSource()
            {
                name = "CountriesForContinent",
                DataSourceDetails = new SqlDataSource()
                {
                    connection = "demoDatabase",
                    sqlCommand = DropDownSourceHelper.IncludeNull("Countries", "Name", "Name", "Name",seedCol: "ContinentName",seedLike: false),
                    isAudit = true
                }
            });

            ctx.SaveChanges();
        }
    }
}

