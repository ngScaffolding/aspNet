using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ngScaffolding.database.Models
{
    //[DataContract(IsReference = true)]
    public class Dashboard
    {
        public Dashboard()
        {
            Widgets = new List<Widget>();
        }

        public int DashboardID { get; set; }
        public string Title { get; set; }
        public string OwnerUserName { get; set; }
        public bool? ReadOnly { get; set; }

        public virtual ICollection<Widget> Widgets { get; set; }
        //public virtual ICollection<ApplicationRole> Roles { get; set; }
        //public virtual ICollection<ApplicationUser> Users { get; set; }
    }

    public class Widget
    {
        
        public int WidgetID { get; set; }
        public string Title { get; set; }
        public string ConfiguredValues { get; set; }
        public int? col { get; set; }
        public int? row { get; set; }
        public int? sizeX { get; set; }
        public int? sizeY { get; set; }
        public string style { get; set; }
        public int? refreshInterval { get; set; }

        public int DashboardID { get; set; }
        [ForeignKey("DashboardID")]
        public virtual Dashboard Dashboard { get; set; }

        public int WidgetTemplateID { get; set; }
        [ForeignKey("WidgetTemplateID")]
        public virtual WidgetTemplate WidgetTemplate { get; set; }
    }

    public class WidgetTemplate
    {
        public int WidgetTemplateID { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string TemplateURL { get; set; }
        public string ConfigJson { get; set; }
        public string Icon { get; set; }
        public string InputParameters { get; set; }
        public string DefaultStyle { get; set; }
        public int? DefaultSizeX { get; set; }
        public int? DefaultSizeY { get; set; }
        public int? DefaultRefreshInterval { get; set; }

        public string WidgetDataSource { get; set; }
        public virtual ICollection<Widget> Widgets { get; set; }
    }

    public class WidgetTemplateRole
    {
        public int WidgetTemplateRoleID { get; set; }
        

        public int WidgetTemplateID { get; set; }
        [ForeignKey("WidgetTemplateID")]
        public virtual WidgetTemplate WidgetTemplate { get; set; }
    }
}