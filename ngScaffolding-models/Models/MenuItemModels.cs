using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ngScaffolding.Models;
using Newtonsoft.Json;

namespace ngScaffolding.database.Models
{
    public class MenuItem : MenuElement
    {
        private string _jsonSerialized;
        private MenuItemDetail _menuItemDetail;
        public const string Type_Folder = "Folder";
        public const string Type_GridView = "GridView";
        public const string Type_Dashboard = "Dashboard";
        public const string Type_View = "View";
        public const string Type_Controller = "Controller";

        public MenuItem()
        {
            //Items = new List<MenuItem>();
        }

        public MenuItem(MenuItem menu) : base()
        {
            Label = menu.Label;
            ParentMenuItemId = menu.ParentMenuItemId;
            ItemOrder = menu.ItemOrder;
            JsonSerialized = menu.JsonSerialized;
            Command = menu.Command;
            RouterLink = menu.RouterLink;
            RouterLinkActiveOptions = menu.RouterLinkActiveOptions;
            Target = menu.Target;
            Separator = menu.Separator;
            Badge = menu.Badge;
            BadgeStyleClass = menu.BadgeStyleClass;
            Style = menu.Style;
            StyleClass = menu.StyleClass;
        }
        // Following are copied from PrimeNG MenuItem

        public bool Expanded { get; set; }
        public bool Disabled { get; set; }
        public bool Visible { get; set; }

        [StringLength(100)]
        public string Type { get; set; }

        public int? ItemOrder { get; set; }

        [NotMapped]
        public MenuItemDetail MenuItemDetail
        {
            get { return _menuItemDetail; }
            set
            {
                _jsonSerialized = JsonConvert.SerializeObject(value);
                _menuItemDetail = value;
            }
        }

        public string JsonSerialized
        {
            get
            { return _jsonSerialized; }
            set
            {
                if (value != null)
                {
                    this.MenuItemDetail = JsonConvert.DeserializeObject<MenuItemDetail>(value);
                }

                _jsonSerialized = value;
            }
        }

        public int? ParentMenuItemId { get; set; }
        [ForeignKey("ParentMenuItemId")]
        public virtual MenuItem ParentMenuItem { get; set; }

        //public IEnumerable<MenuItem> Items { get; set; }
    }
}