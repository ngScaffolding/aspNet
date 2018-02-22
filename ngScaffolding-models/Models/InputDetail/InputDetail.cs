using ngScaffolding.models.Models;

namespace ngScaffolding.database.Models
{
    public class InputDetail
    {

        //Shared
        public string Name { get; set; }
        public string Type { get; set; } //textbox, email, textarea, select, multiselect, date, datetime
        public string Label { get; set; }
        public string Placeholder { get; set; }
        public string Help { get; set; }

        public string Comparison { get; set; }
        public bool Allowcomparisonchange { get; set; }
        public bool Required { get; set; }

        public string Classes { get; set; }
        public string ContainerClass { get; set; }
        public string Hidden { get; set; }

        public string Value { get; set; }

        public string ValidateRequired { get; set; } // Providing a message here infer Required
        public string ValidateRequiredTrue { get; set; } // Providing a message here infer RequiredTrue

        public string ValidateEmail { get; set; } // Providing a message here infer RequiredEmail

        public string ValidatePattern { get; set; }
        public string ValidatePatternMessage { get; set; }

        public int ValidateMinLength { get; set; }
        public string ValidateMinLengthMessage { get; set; }

        public int ValidateMaxLength { get; set; }
        public string ValidateMaxLengthMessage { get; set; }

        public const string Type_Textbox = "textbox";
        public const string Type_Email = "email";
        public const string Type_Password = "password";
        public const string Type_Textarea = "textarea";
        public const string Type_Datetime = "datetime";
        public const string Type_Date = "date";
        public const string Type_Time = "time";
        public const string Type_Select = "select";
        public const string Type_Switch = "switch";
        public const string Type_Editor = "editor";
        public const string Type_Listbox = "listbox";
        public const string Type_Colorpicker = "colorpicker";
        public const string Type_Spinner = "spinner";
        public const string Type_Slider = "slider";
        public const string Type_Checkbox = "checkbox";
        public const string Type_Tricheckbox = "tricheckbox";
        public const string Type_Selectbutton = "selectbutton";
        public const string Type_Togglebutton = "togglebutton";
        public const string Type_Radio = "radio";
        public const string Type_Dropdown = "dropdown";
        public const string Type_Rating = "rating";
        public const string Type_Autocomplete = "autocomplete";
        public const string Type_Multiselect = "multiselect";
        public const string Type_Chips = "chips";
    }
    public class InputDetailTextBox : InputDetail
    {
        public InputDetailTextBox(): base()
        {
            this.Type = InputDetail.Type_Textbox;
        }
        public string Mask { get; set; } // 999-999
    }
    public class InputDetailReferenceValues : InputDetail
    {
        public string ReferenceValueName { get; set; }  // Used for select items
        public string ReferenceValueSeedName { get; set; }  // set to name, when changed use this value in search
        public string ReferenceValueSeedDependency { get; set; }  // Name of control to use as seed for this DataSource... Used linked Dropdowns
    }
    public class InputDetailDropdown : InputDetailReferenceValues
    {
        public InputDetailDropdown(): base()
        {
            this.Type = InputDetail.Type_Dropdown;
        }
        public bool SelectFilter { get; set; }  // Show Filter on Select Dropdown
        public string SelectFilterBy { get; set; }  // Fields to filter by on Select DropDown
        public string SelectFilterPlaceholder { get; set; }  // Placeholder for Filter input
    }

    public class InputDetailToggleButton : InputDetail
    {
        public InputDetailToggleButton(): base()
        {
            this.Type = InputDetail.Type_Togglebutton;
        }
        public string OnLabel { get; set; }  // Labels for ToggleButton
        public string OffLabel { get; set; }  // Labels for ToggleButton
    }
    public class InputDetailTextArea : InputDetail
    {
        public InputDetailTextArea(): base()
        {
            this.Type = InputDetail.Type_Textarea;
        }
        public int Rows { get; set; }  // Rows for TextArea
    }
}