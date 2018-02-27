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
                    new ReferenceValueItem(){ Value="HORIZONTAL", Display = "Horizontal" },
                    new ReferenceValueItem(){ Value="STATIC", Display = "Side Static" },
                    new ReferenceValueItem(){ Value="OVERLAY", Display = "Side Overlay" },
                    new ReferenceValueItem(){ Value="SLIM", Display = "Side Slim" }
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
