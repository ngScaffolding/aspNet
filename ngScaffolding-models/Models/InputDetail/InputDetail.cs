using ngScaffolding.models.Models;

namespace ngScaffolding.database.Models
{
    public class InputDetail
    {

        //Shared
        public string name { get; set; }
        public string type { get; set; } //textbox, email, textarea, select, multiselect, date, datetime
        public string label { get; set; }
        public string placeholder { get; set; }
        public string help { get; set; }

        public string comparison { get; set; }
        public bool allowcomparisonchange { get; set; }
        public bool required { get; set; }

        public string classes { get; set; }
        public string containerClass { get; set; }
        public string hidden { get; set; }

        public string defaultValue { get; set; }

        public string validateRequired { get; set; } // Providing a message here infer Required
        public string validateRequiredTrue { get; set; } // Providing a message here infer RequiredTrue

        public string validateEmail { get; set; } // Providing a message here infer RequiredEmail

        public string validatePattern { get; set; }
        public string validatePatternMessage { get; set; }

        public int validateMinLength { get; set; }
        public string validateMinLengthMessage { get; set; }

        public int validateMaxLength { get; set; }
        public string validateMaxLengthMessage { get; set; }

        public const string Type_Textbox = "textbox";
        public const string Type_Email = "email";
        public const string Type_Password = "password";
        public const string Type_Textarea = "textarea";
        public const string Type_Datetime = "datetime";
        public const string Type_Date = "date";
        public const string Type_Time = "time";
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
            this.type = InputDetail.Type_Textbox;
        }
        public string Mask { get; set; } // 999-999
    }
    public class InputDetailReferenceValues : InputDetail
    {
        public string referenceValueName { get; set; }  // Used for select items
        public string referenceValueSeedName { get; set; }  // set to name, when changed use this value in search
        public string referenceValueSeedDependency { get; set; }  // Name of control to use as seed for this DataSource... Used linked Dropdowns
    }
    public class InputDetailSelect: InputDetailDropdown
    {
        public InputDetailSelect(): base()
        {
            this.type = InputDetail.Type_Dropdown;
        }
    }
    public class InputDetailDropdown : InputDetailReferenceValues
    {
        public InputDetailDropdown(): base()
        {
            this.type = InputDetail.Type_Dropdown;
        }
        public bool selectFilter { get; set; }  // Show Filter on Select Dropdown
        public string selectFilterBy { get; set; }  // Fields to filter by on Select DropDown
        public string selectFilterPlaceholder { get; set; }  // Placeholder for Filter input
    }

    public class InputDetailToggleButton : InputDetail
    {
        public InputDetailToggleButton(): base()
        {
            this.type = InputDetail.Type_Togglebutton;
        }
        public string onLabel { get; set; }  // Labels for ToggleButton
        public string offLabel { get; set; }  // Labels for ToggleButton
    }
    public class InputDetailTextArea : InputDetail
    {
        public InputDetailTextArea(): base()
        {
            this.type = InputDetail.Type_Textarea;
        }
        public int rows { get; set; }  // Rows for TextArea
    }

    public class InputDetailSwitch : InputDetail
    {
        public InputDetailSwitch() : base()
        {
            this.type = InputDetail.Type_Switch;
        }
    }
}