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

            scaffoldingContext.UserPreferencesDefinitions.Add(new models.Models.UserPreferenceDefinition()
            {
                Name = "MenuOrientation",
                InputDetails = JsonConvert.SerializeObject(new InputDetailDropdown()
                {
                    Name = "MenuOrientation",
                    Label = "Menu Type",
                    Help = "Select the type of menu for the application",
                    ReferenceValueName = "UserPrefs_MenuOrientation",
                    Value = "horizontal"
                })
            });
        }
    }
}
