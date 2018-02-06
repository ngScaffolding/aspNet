using ngScaffolding.database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ngScaffolding.Data;

namespace ngScaffolding.ConfigHelpers
{
    public class MenuHelper
    {
        public static MenuItem AddMenu(ngScaffoldingContext context, MenuItem menu) {
            MenuItem newMenu = null;

            if(context.MenuItems.Any(m => m.Label == menu.Label))
            {
                newMenu = context.MenuItems.First(m => m.Label == menu.Label);
            }
            else
            {
                newMenu = new MenuItem() { Label = menu.Label };
                context.MenuItems.Add(newMenu);
            }

            newMenu.ParentMenuItemId = menu.ParentMenuItemId;
            newMenu.ItemOrder = menu.ItemOrder;
            newMenu.JsonSerialized = menu.JsonSerialized;
            newMenu.Command = menu.Command;
            newMenu.RouterLink = menu.RouterLink;
            newMenu.RouterLinkActiveOptions = menu.RouterLinkActiveOptions;
            newMenu.Target = menu.Target;
            newMenu.Separator = menu.Separator;
            newMenu.Badge = menu.Badge;
            newMenu.BadgeStyleClass = menu.BadgeStyleClass;
            newMenu.Style = menu.Style;
            newMenu.StyleClass = menu.StyleClass;

            newMenu.Name = menu.Name;
            newMenu.Roles = menu.Roles;
            newMenu.ItemOrder = menu.ItemOrder;
            newMenu.Type = menu.Type;

            context.SaveChanges();

            return newMenu;
        }
    }
}
