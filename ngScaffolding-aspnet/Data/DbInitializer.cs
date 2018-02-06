using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ngScaffolding.Data;
using ngScaffolding.models.Models;

namespace ngScacffolding.Data
{
    public class DbInitializer
    {
        public static void Initialize(ngScaffoldingContext scaffoldingContext)
        {
            scaffoldingContext.Database.EnsureCreated();

            // Look for any Countries.
            if (scaffoldingContext.ApplicationLogs.Any())
            {
                return; // DB has been seeded
            }

            // Add Log Entry
            scaffoldingContext.ApplicationLogs.Add(new ApplicationLog()
            {
                Description = "Database Created",
                LogDate = DateTime.Now
            });

            scaffoldingContext.SaveChanges();
            
        }
    }
}
