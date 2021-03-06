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

            if(context.MenuItems.Any(m => m.name == menu.name))
            {
                newMenu = context.MenuItems.First(m => m.name == menu.name);
            }
            else
            {
                newMenu = new MenuItem() { name = menu.name };
                context.MenuItems.Add(newMenu);
            }

            newMenu.parentMenuItemId = menu.parentMenuItemId;
            newMenu.itemOrder = menu.itemOrder;
            newMenu.jsonSerialized = menu.jsonSerialized;
            newMenu.command = menu.command;
            newMenu.routerLink = menu.routerLink;
            newMenu.routerLinkActiveOptions = menu.routerLinkActiveOptions;
            newMenu.target = menu.target;
            newMenu.separator = menu.separator;
            newMenu.badge = menu.badge;
            newMenu.badgeStyleClass = menu.badgeStyleClass;
            newMenu.style = menu.style;
            newMenu.styleClass = menu.styleClass;
            newMenu.label = menu.label;
            newMenu.icon = menu.icon;
            newMenu.Description = menu.Description;
            newMenu.Url = menu.Url;
            newMenu.separator = menu.separator;
            
            newMenu.name = menu.name;
            newMenu.roles = menu.roles;
            newMenu.itemOrder = menu.itemOrder;
            newMenu.type = menu.type;

            context.SaveChanges();

            return newMenu;
        }
    }
}
