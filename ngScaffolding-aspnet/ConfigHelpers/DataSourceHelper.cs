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
            if (context.DataSources.Any(m => m.Name == reference.Name))
            {
                var existing = context.DataSources.First(m => m.Name == reference.Name);

                context.DataSources.Remove(existing);

                context.SaveChanges();
            }

            var newItem = new DataSource() {Name = reference.Name};
            context.DataSources.Add(newItem);

            newItem.Name = reference.Name;
            newItem.Type = reference.Type;
            newItem.JsonContent = reference.JsonContent;

            context.SaveChanges();

            return newItem;
        }
    }
}
