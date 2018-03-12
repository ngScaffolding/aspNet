using Newtonsoft.Json;
using ngScaffolding.database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ngScaffolding.Data
{
    public class UserPreferencesConfig
    {
        public static void Build(ngScaffoldingContext scaffoldingContext)
        {
            if (scaffoldingContext.UserPreferencesDefinitions.Any())
            {
                return;
            }

            // Menu Orientation
            scaffoldingContext.ReferenceValues.Add(new ReferenceValue
            {
                Name = "UserPrefs_MenuOrientation",
                Type = ReferenceValue.Types_List,
                GroupName = "UserPrefs",
                ReferenceValueItems = new List<ReferenceValueItem>() {
                    new ReferenceValueItem(){ Value="0", Display = "Side Static" },
                    new ReferenceValueItem(){ Value="1", Display = "Side Overlay" },
                    new ReferenceValueItem(){ Value="2", Display = "Side Slim" },
                    new ReferenceValueItem(){ Value="3", Display = "Horizontal" }
                }
            });

            // Themes
            scaffoldingContext.ReferenceValues.Add(new ReferenceValue
            {
                Name = "UserPrefs_Themes",
                Type = ReferenceValue.Types_List,
                GroupName = "UserPrefs",
                ReferenceValueItems = new List<ReferenceValueItem>() {
                    new ReferenceValueItem(){ Display = "Indigo - Pink", Value = "indigo" },
                    new ReferenceValueItem(){ Display = "Brown - Green", Value="brown" },
                    new ReferenceValueItem(){ Display = "Blue - Amber", Value="blue" },
                    new ReferenceValueItem(){ Display = "Blue - Grey", Value="blue-grey" },
                    new ReferenceValueItem(){ Display = "Dark - Blue", Value="dark-blue" },
                    new ReferenceValueItem(){ Display = "Dark - Green", Value="dark-green" },
                    new ReferenceValueItem(){ Display = "Green - Yellow", Value="green" },
                    new ReferenceValueItem(){ Display = "Purple - Cyan", Value="purple-cyan" },
                    new ReferenceValueItem(){ Display = "Purple - Amber", Value="purple-amber" },
                    new ReferenceValueItem(){ Display = "Teal - Lime", Value="teal" },
                    new ReferenceValueItem(){ Display = "Cyan - Amber", Value="cyan" },
                    new ReferenceValueItem(){ Display = "Grey - Deep", Value="grey" }
                }
            });

            // Profile Modes
            scaffoldingContext.ReferenceValues.Add(new ReferenceValue
            {
                Name = "UserPrefs_ProfileMode",
                Type = ReferenceValue.Types_List,
                GroupName = "UserPrefs",
                ReferenceValueItems = new List<ReferenceValueItem>() {
                    new ReferenceValueItem(){ Value="top", Display = "Top" },
                    new ReferenceValueItem(){ Value="inline", Display = "Inline (Menu)" }
                }
            });

            // Themes
            scaffoldingContext.UserPreferencesDefinitions.Add(new models.Models.UserPreferenceDefinition()
            {
                Name = "Theme",
                InputDetails = JsonConvert.SerializeObject(new InputDetailSelect()
                {
                    name = "Theme",
                    label = "Theme",
                    help = "Select the Theme",
                    referenceValueName = "UserPrefs_Themes"
                })
            });

            scaffoldingContext.UserPreferencesDefinitions.Add(new models.Models.UserPreferenceDefinition()
            {
                Name = "MenuOrientation",
                InputDetails = JsonConvert.SerializeObject(new InputDetailSelect()
                {
                    name = "MenuOrientation",
                    label = "Menu Type",
                    help = "Select the type of menu for the application",
                    referenceValueName = "UserPrefs_MenuOrientation",
                    defaultValue = "horizontal"
                })
            });

            // Profile Mode
            scaffoldingContext.UserPreferencesDefinitions.Add(new models.Models.UserPreferenceDefinition()
            {
                Name = "ProfileMode",
                InputDetails = JsonConvert.SerializeObject(new InputDetailSelect()
                {
                    name = "ProfileMode",
                    label = "Profile Mode",
                    help = "Select the position of the Profile Icon",
                    referenceValueName = "UserPrefs_ProfileMode",
                    defaultValue = "inline"
                })
            });

            // Compact Mode
            scaffoldingContext.UserPreferencesDefinitions.Add(new models.Models.UserPreferenceDefinition()
            {
                Name = "CompactMode",
                InputDetails = JsonConvert.SerializeObject(new InputDetailSwitch()
                {
                    name = "CompactMode",
                    label = "Compact Mode",
                    help = "Select the Compact/Expand Mode"
                })
            });
            
            // Dark Menu
            scaffoldingContext.UserPreferencesDefinitions.Add(new models.Models.UserPreferenceDefinition()
            {
                Name = "DarkMenu",
                InputDetails = JsonConvert.SerializeObject(new InputDetailSwitch()
                {
                    name = "DarkMenu",
                    label = "Dark/Light Menu",
                    help = "Dark or Light Menu"
                })
            });
        }
    }
}
