using System;
using System.Collections.Generic;
using System.Text;

namespace ngScaffolding.ConfigHelpers
{
    public class DropDownSourceHelper
    {
        public static string IncludeNull(string tableName, string valueCol, string displayCol, string orderCol = "", string seedCol = "", bool seedLike = false)
        {
            var retVal = NonNull(tableName,valueCol, displayCol, orderCol, seedCol, seedLike);

            if (!string.IsNullOrEmpty(orderCol))
            {
                retVal = $"SELECT NULL as value, ''(None)'' as display, null as [orderby] UNION {retVal}";
            }
            else
            {
                retVal = $"SELECT NULL as value, ''(None)'' as display UNION {retVal}";
            }

            return retVal;
        }

        public static string NonNull(string tableName,string valueCol, string displayCol, string orderCol = "", string seedCol = "", bool seedLike = false)
        {
            var whereClause = "";

            if (!string.IsNullOrEmpty(seedCol))
            {
                if (seedLike)
                {
                    whereClause = $"WHERE [{seedCol}] LIKE ''%@@SEED%''";
                }
                else
                {
                    whereClause = $"WHERE [{seedCol}] = ''@@SEED''";
                }
            }

            if (!string.IsNullOrEmpty(orderCol))
            {
                return $"SELECT [{valueCol}] as [value], [{displayCol}] as [display], [{orderCol}] as [orderby] FROM [{tableName}] {whereClause} ORDER BY [orderby]";
            }
            else
            {
                return $"SELECT [{valueCol}] as [value], [{displayCol}] as [display] FROM [{tableName}] {whereClause}";
            }
        }
    }
}
