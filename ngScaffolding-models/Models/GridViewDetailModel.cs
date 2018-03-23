using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using ngScaffolding.database.Models;
using ngScaffolding.Models.DataSourceModels;

namespace ngScaffolding.Models
{
    public class GridViewDetailModel: MenuItemDetail
    {
        public string Title { get; set; }
        public bool WaitForInput { get; set; }

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

        public string FiltersLocation { get; set; }

        public InputBuilderDefinition Filters { get; set; }

        // Select DataSource
        public int? SelectDataSourceId { get; set; }
        [ForeignKey("SelectDataSourceId")]
        [JsonIgnoreAttribute]
        public virtual DataSource SelectDataSource { get; set; }

        // Delete Datasource
        public int? DeleteDataSourceId { get; set; }
        [ForeignKey("DeleteDataSourceId")]
        [JsonIgnoreAttribute]
        public virtual DataSource DeleteDataSource { get; set; }

        // Update DataSource
        public int? UpdateDataSourceId { get; set; }
        [ForeignKey("UpdateDataSourceId")]
        [JsonIgnoreAttribute]
        public virtual DataSource UpdateDataSource { get; set; }

        // Insert DataSource
        public int? InsertDataSourceId { get; set; }
        [ForeignKey("InsertDataSourceId")]
        [JsonIgnoreAttribute]
        public virtual DataSource InsertDataSource { get; set; }

        public ICollection<ActionModel> Actions { get; set; }
    }
}