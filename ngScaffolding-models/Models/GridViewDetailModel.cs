using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using ngScaffolding.database.Models;
using ngScaffolding.Models.DataSourceModels;

namespace ngScaffolding.Models
{
    public class GridViewDetailModel : MenuItemDetail
    {
        public string Title { get; set; }
        public bool WaitForInput { get; set; }
        public bool DisableCheckboxSelection { get; set; }

        public int? PageSize { get; set; }
        public bool InfiniteScroll { get; set; }

        public string DetailUrl { get; set; }
        public string DetailTarget { get; set; }

        public bool ServerPagination { get; set; }
        public bool ServerSorting { get; set; }
        public bool ServerGrouping { get; set; }

        public string DefaultSort { get; set; }

        public ICollection<ColumnModel> Columns { get; set; }
        public ICollection<ColumnModel> ConfiguredColumns { get; set; }

        // this is used to send the row Id to the Action buttons
        public string IdField { get; set; }

        public string FiltersLocation { get; set; }

        public InputBuilderDefinition Filters { get; set; }

        // Select DataSource
        public int? SelectDataSourceId { get; set; }

        // Delete Datasource
        public int? DeleteDataSourceId { get; set; }

        // Update DataSource
        public int? UpdateDataSourceId { get; set; }

        // Insert DataSource
        public int? InsertDataSourceId { get; set; }

        public ICollection<ActionModel> Actions { get; set; }
    }
}