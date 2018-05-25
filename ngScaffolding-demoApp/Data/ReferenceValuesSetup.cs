using ngScaffolding.ConfigHelpers;
using ngScaffolding.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ngScaffolding.database.Models;

namespace ngScacffolding.demoApp
{
    public class ReferenceValuesSetup
    {
        public static void Setup(ngScaffoldingContext ctx)
        {
            ReferenceValueHelper.Add(ctx, new ngScaffolding.database.Models.ReferenceValue()
            {
                name = "Continents",
                Type = ReferenceValue.Types_DatabaseQuery,
                ConnectionName = "demoDatabase",
                Value = DropDownSourceHelper.IncludeNull("Continents", "Id", "Name", "Name")
            });

            ReferenceValueHelper.Add(ctx, new ngScaffolding.database.Models.ReferenceValue()
            {
                name = "Countries",
                Type = ReferenceValue.Types_DatabaseQuery,
                ConnectionName = "demoDatabase",
                Value = DropDownSourceHelper.IncludeNull("Countries", "Id", "Name", "Name")
            });

            ReferenceValueHelper.Add(ctx, new ngScaffolding.database.Models.ReferenceValue()
            {
                name = "CountriesForContinent",
                Type = ReferenceValue.Types_DatabaseQuery,
                ConnectionName = "demoDatabase",
                Value = DropDownSourceHelper.IncludeNull("Countries", "Id", "Name", "Name", "ContinentName")
            });
            
            ctx.SaveChanges();
        }
    }
}
