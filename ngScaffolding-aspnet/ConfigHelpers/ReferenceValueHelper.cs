using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ngScaffolding.database.Models;
using ngScaffolding.Data;

namespace ngScaffolding.ConfigHelpers
{
    public class ReferenceValueHelper
    {
        public static ReferenceValue Add(ngScaffoldingContext context, ReferenceValue reference)
        {
            //ReferenceValue newReference = null;

            if (context.ReferenceValues.Any(m => m.name == reference.name))
            {
                var existing = context.ReferenceValues.First(m => m.name == reference.name);

                context.ReferenceValues.Remove(existing);

                context.SaveChanges();
            }
            //else
            //{
                var newReference = new ReferenceValue() { name = reference.name };
                context.ReferenceValues.Add(newReference);

            //}
            
            newReference.GroupName = reference.GroupName;
            newReference.Type = reference.Type;
            newReference.Value = reference.Value;
            newReference.ConnectionName = reference.ConnectionName;
            newReference.CacheSeconds = reference.CacheSeconds;
            newReference.Authorisation = reference.Authorisation;
            newReference.InputDetails = reference.InputDetails;

            newReference.ReferenceValueItems = reference.ReferenceValueItems;
            
            context.SaveChanges();

            return newReference;
        }
    }
}
