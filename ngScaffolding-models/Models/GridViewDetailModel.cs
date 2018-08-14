using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using ngScaffolding.database.Models;
using ngScaffolding.Models.DataSourceModels;

namespace ngScaffolding.Models
{
    public class GridViewDetailModel : MenuItemDetail
    {
        public string title { get; set; }
        public bool waitForInput { get; set; }
        public bool disableCheckboxSelection { get; set; }

        public int? pageSize { get; set; }
        public bool infiniteScroll { get; set; }

        public string detailUrl { get; set; }
        public string detailTarget { get; set; }

        public bool serverPagination { get; set; }
        public bool serverSorting { get; set; }
        public bool serverGrouping { get; set; }

        public string defaultSort { get; set; }

        public ICollection<ColumnModel> columns { get; set; }
        public ICollection<ColumnModel> configuredColumns { get; set; }

        // this is used to send the row Id to the Action buttons
        public string idField { get; set; }

        public bool isActionColumnSplitButton { get; set; }

        public string filtersLocation { get; set; }

        public InputBuilderDefinition filters { get; set; }

        // Select DataSource
        public string selectDataSourceName { get; set; }

        public ICollection<ActionModel> actions { get; set; }
    }
}