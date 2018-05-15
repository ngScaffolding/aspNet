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
        public const string Type_Chart = "Chart";
        public const string Type_View = "View";
        public const string Type_Controller = "Controller";

        public MenuItem()
        {
            Items = new List<MenuItem>();
        }

        public MenuItem(MenuItem menu) : base()
        {
            label = menu.label;
            parentMenuItemId = menu.parentMenuItemId;
            itemOrder = menu.itemOrder;
            jsonSerialized = menu.jsonSerialized;
            command = menu.command;
            routerLink = menu.routerLink;
            routerLinkActiveOptions = menu.routerLinkActiveOptions;
            target = menu.target;
            separator = menu.separator;
            badge = menu.badge;
            icon = menu.icon;
            badgeStyleClass = menu.badgeStyleClass;
            style = menu.style;
            styleClass = menu.styleClass;

        
    }
    // Following are copied from PrimeNG MenuItem

    public bool? expanded { get; set; }
        public bool? disabled { get; set; }
        public bool? visible { get; set; }

        [StringLength(100)]
        public string type { get; set; }

        public int? itemOrder { get; set; }

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

        public string jsonSerialized
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

        public int? parentMenuItemId { get; set; }
        [ForeignKey("parentMenuItemId")]
        public virtual MenuItem ParentMenuItem { get; set; }

        [NotMapped]
        public ICollection<MenuItem> Items { get; set; }
    }
}