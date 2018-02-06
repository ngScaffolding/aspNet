using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ngScaffolding.database;

namespace ngScaffolding.database
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<ngScaffoldingContext>
    {
        public ngScaffoldingContext CreateDbContext(string[] args)
        {
           
            var builder = new DbContextOptionsBuilder<ngScaffoldingContext>();

            var connectionString =
                @"Server=(localdb)\mssqllocaldb;Database=ngScaffolding;Trusted_Connection=True;MultipleActiveResultSets=true";

            builder.UseSqlServer(connectionString);

            return new ngScaffoldingContext(builder.Options);
        }
    }
}