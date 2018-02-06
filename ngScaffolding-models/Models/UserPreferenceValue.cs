namespace ngScaffolding.models.Models
{
    public class UserPreferenceValue : BaseEntity
    {
        public string UserName { get; set; }
        public string PreferenceName { get; set; }
        public string Value { get; set; }

        public virtual UserPreference UserPreference { get; set; }
    }
}
