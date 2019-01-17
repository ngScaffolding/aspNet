using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ngScaffolding.demoSetup;
using ngScaffolding.Data;

namespace ngScacffolding.demoApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(DemoContext context, ngScaffoldingContext scaffoldingContext)
        {
            context.Database.EnsureCreated();
            scaffoldingContext.Database.EnsureCreated();

            SetupGeography.Setup(context);
            DataSourceSetup.Setup(scaffoldingContext);
            ReferenceValuesSetup.Setup(scaffoldingContext);
            MenuItems.Setup(scaffoldingContext);
            APIMenuItems.Setup(scaffoldingContext);
        }
    }
}
