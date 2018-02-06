using System.Collections.Generic;
using ngScaffolding.database.Models;
using ngScaffolding.models.Models;

namespace ngScaffolding.Models
{
    public class ActionModel:BaseRoleEntity
    {
        public class ActionTypes
        {
            public const string SqlCommand = "SQLCOMMAND";
            public const string RestApi = "RESTAPI";
            public const string Url = "URL";
            public const string Detail = "DETAIL";
            public const string AngularController = "ANGULARCONTROLLER";
        }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Colour { get; set; }

        // Does this Action appear in a Grid column?
        public bool ColumnButton { get; set; }

        // Do we need to have atleast one Soure selected?
        public bool SelectionRequired { get; set; }

        // After Action completes, remove these DataSources from cache
        public string FlushDataSource { get; set; }

        // Does the action work on multiple rows?
        public bool MultipleTarget { get; set; }

        // Message to show on Confirmation of Action
        public string ConfirmationMessage { get; set; }

        public string IdField { get; set; }
        public string IdValue { get; set; }
        public string EntityType { get; set; }
        public string AdditionalProperties { get; set; }
        public ICollection<InputDetail> InputControls { get; set; }
        public bool Refresh { get; set; }

        public bool IsAudit { get; set; }

        // Done message
        public string Success { get; set; }
        // Not done
        public string Error { get; set; }

        // For SQL this contains the SQL Command ID
        public string ActionDefinition { get; set; }

        //Angular Controller content
        //Todo: Not sure if we need this - Maybe just a route?
        public string Controller { get; set; }
        public string TemplateUrl { get; set; }

        //Standard Url
        public string Url { get; set; }
        public string Target { get; set; }

        //_blank - URL is loaded into a new window.This is default
        //_parent - URL is loaded into the parent frame
        //_self - URL replaces the current page
        //_top - URL replaces any framesets that may be loaded
    }
}