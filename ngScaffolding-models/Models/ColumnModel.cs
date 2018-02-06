namespace ngScaffolding.Models
{
    public class ColumnModel
    {
        private string _field;

        public string Field
        {
            get { return _field; }
            set
            {
                if (!string.IsNullOrEmpty(value) && string.IsNullOrEmpty(HeaderName))
                {
                    HeaderName = value;
                }
                _field = value;
            }
        }

        public string CellClass { get; set; }
        public string Filter { get; set; }
        public string TooltipField { get; set; }
        public string HeaderName { get; set; }
        public string HeaderTooltip { get; set; }
        public string Pinned { get; set; } // left or right
        public bool SuppressMenu { get; set; }
        public bool SuppressFilter { get; set; }
        public bool SuppressSorting { get; set; }
        //public int minWidth { get; set; }
        //public int maxWidth { get; set; }
        public string Type { get; set; }
        public bool Hide { get; set; }
        public string Width { get; set; }

        public string CellFormatter { get; set; }
        public string CellClassRules { get; set; }

        //Link & Action Buttons
        public string DestinationUrl { get; set; }
        public string Target { get; set; }
        public string ButtonTitle { get; set; }
        public string ButtonIcon { get; set; }
    }
}