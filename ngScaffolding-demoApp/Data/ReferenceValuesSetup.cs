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
                Name = "Continents",
                Type = ReferenceValue.Types_DatabaseQuery,
                ConnectionName = "demoDatabase",
                Value = DropDownSourceHelper.IncludeNull("Continents", "Name", "Name", "Name")
            });

            ReferenceValueHelper.Add(ctx, new ngScaffolding.database.Models.ReferenceValue()
            {
                Name = "Countries",
                Type = ReferenceValue.Types_DatabaseQuery,
                ConnectionName = "demoDatabase",
                Value = DropDownSourceHelper.IncludeNull("Countries", "Name", "Name", "Name")
            });

            ReferenceValueHelper.Add(ctx, new ngScaffolding.database.Models.ReferenceValue()
            {
                Name = "CountriesForContinent",
                Type = ReferenceValue.Types_DatabaseQuery,
                ConnectionName = "demoDatabase",
                Value = DropDownSourceHelper.IncludeNull("Countries", "Name", "Name", "Name", "ContinentName")
            });
            
            ctx.SaveChanges();
        }
    }
}
