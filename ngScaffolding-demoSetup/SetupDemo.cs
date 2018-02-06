using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ngScaffolding.database;
using ngScaffolding.database.ConfigHelpers;
using ngScaffolding.demoSetup;
using ngScaffolding.Models;
using ngScaffolding.Models.DataSourceModels;
using Newtonsoft.Json;

namespace ngScaffolding.demoSetup
{
    class SetupDemo
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var connStringScaffolding = configuration.GetConnectionString("ngScaffolding");
            var connStringDemo = configuration.GetConnectionString("demoDatabase");

            var dbBuilder = new DbContextOptionsBuilder<ngScaffoldingContext>();
            dbBuilder.UseSqlServer(connStringScaffolding);
            var ctx = new ngScaffoldingContext(dbBuilder.Options);

            var dbBuilderDemo = new DbContextOptionsBuilder<DemoContext>();
            dbBuilderDemo.UseSqlServer(connStringDemo);
            var ctxDemo = new DemoContext(dbBuilderDemo.Options);

            SetupGeography.Setup(ctx, ctxDemo);

            DataSourceSetup.Setup(ctx);
        }
    }
}
