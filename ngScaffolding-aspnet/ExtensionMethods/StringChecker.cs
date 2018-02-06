using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ngScaffolding.ExtensionMethods
{
    public static class StringChecker
    {
        public static bool IsNullOrEmpty(string value)
        {
            if (!string.IsNullOrEmpty(value) && value.ToUpper() == "NULL")
            {
                return true;
            }
            else
            {
                return string.IsNullOrEmpty(value);
            }
        }
    }
}
