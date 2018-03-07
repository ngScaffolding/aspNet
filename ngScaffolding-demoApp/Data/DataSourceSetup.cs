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
                Name = "Continents",
                Type = DataSource.TypesSql,
                DataSourceDetails = new SqlDataSource()
                {
                    Connection = "demoDatabase",
                    SqlCommand = DropDownSourceHelper.IncludeNull("Continents", "Name", "Name", "Name"),
                    IsAudit = true
                }
            });

            DataSourceHelper.Add(ctx, new DataSource()
            {
                Name = "CountriesForContinent",
                Type = DataSource.TypesSql,
                DataSourceDetails = new SqlDataSource()
                {
                    Connection = "demoDatabase",
                    SqlCommand = DropDownSourceHelper.IncludeNull("Countries", "Name", "Name", "Name",seedCol: "ContinentName",seedLike: false),
                    IsAudit = true
                }
            });

            ctx.SaveChanges();
        }
    }
}

