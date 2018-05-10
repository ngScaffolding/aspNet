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
            public const string AngularComponent = "ANGULARCOMPONENT";
        }
        public string type { get; set; }
        public string title { get; set; }
        public string icon { get; set; }
        public string color { get; set; }

        // Does this Action appear in a Grid column?
        public bool columnButton { get; set; }

        // Do we need to have atleast one Soure selected?
        public bool selectionRequired { get; set; }

        // After Action completes, remove these DataSources from cache
        public string flushDataSource { get; set; }

        // Does the action work on multiple rows?
        public bool multipleTarget { get; set; }

        // Message to show on Confirmation of Action
        public string confirmationMessage { get; set; }

        public string idField { get; set; }
        public string idValue { get; set; }
        public string entityType { get; set; }
        public string additionalProperties { get; set; }
        public InputBuilderDefinition inputBuilderDefinition{ get; set; }
        public bool refresh { get; set; }

        public bool isAudit { get; set; }

        // Done message
        public string successMessage { get; set; }
        // Not done
        public string errorMessage { get; set; }

        // For SQL this contains the SQL Command ID
        public int? dataSourceId { get; set; }

        //Angular Controller content
        //Todo: Not sure if we need this - Maybe just a route?
        public string controller { get; set; }
        public string templateUrl { get; set; }

        //Standard Url
        public string url { get; set; }
        public string target { get; set; }

        //_blank - URL is loaded into a new window.This is default
        //_parent - URL is loaded into the parent frame
        //_self - URL replaces the current page
        //_top - URL replaces any framesets that may be loaded
    }
}