using System.Collections.Generic;
using ngScaffolding.database.Models;

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

        public ICollection<InputDetail> Filters { get; set; }

        public DataSource SelectCommand { get; set; }
        public DataSource DeleteCommand { get; set; }
        public DataSource UpdateCommand { get; set; }
        public DataSource InsertCommand { get; set; }

        public ICollection<ActionModel> Actions { get; set; }
    }
}