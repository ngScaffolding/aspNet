using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ngScaffolding.Data;
using ngScaffolding.Models;

namespace ngScaffolding.ConfigHelpers
{
    public class DataSourceHelper
    {
        public static DataSource Add(ngScaffoldingContext context, DataSource reference)
        {
            if (context.DataSources.Any(m => m.name == reference.name))
            {
                var existing = context.DataSources.First(m => m.name == reference.name);

                context.DataSources.Remove(existing);

                context.SaveChanges();
            }

            var newItem = new DataSource() {name = reference.name};
            context.DataSources.Add(newItem);

            newItem.name = reference.name;
            newItem.JsonContent = reference.JsonContent;

            context.SaveChanges();

            return newItem;
        }
    }
}
