namespace ngScaffolding.models.Models
{
    public class UserPreference : BaseEntity
    {
        public string PreferenceName { get; set; }
        public string Value { get; set; }

        public string InputDetails { get; set; }
    }
}