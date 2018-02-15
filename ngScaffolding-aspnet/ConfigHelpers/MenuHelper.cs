﻿using ngScaffolding.database.Models;
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

            if(context.MenuItems.Any(m => m.Name == menu.Name))
            {
                newMenu = context.MenuItems.First(m => m.Name == menu.Name);
            }
            else
            {
                newMenu = new MenuItem() { Name = menu.Name };
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
            newMenu.Label = menu.Label;
            newMenu.Icon = menu.Icon;
            newMenu.Description = menu.Description;
            newMenu.Url = menu.Url;
            newMenu.Separator = menu.Separator;
            
            newMenu.Name = menu.Name;
            newMenu.Roles = menu.Roles;
            newMenu.ItemOrder = menu.ItemOrder;
            newMenu.Type = menu.Type;

            context.SaveChanges();

            return newMenu;
        }
    }
}