using Microsoft.EntityFrameworkCore;
using ngScaffolding.database.Models;
using ngScaffolding.models.Models;
using ngScaffolding.Models;

namespace ngScaffolding.Data
{
    public class ngScaffoldingContext : DbContext
    {
        public ngScaffoldingContext(DbContextOptions<ngScaffoldingContext> options) : base(options)
        {
        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<ErrorModel> Errors { get; set; }

        public DbSet<ReferenceValue> ReferenceValues { get; set; }
        public DbSet<ReferenceValueItem> ReferenceValueItems { get; set; }

        public DbSet<UserPreferenceDefinition> UserPreferencesDefinitions { get; set; }
        public DbSet<UserPreferenceValue> UserPreferenceValues { get; set; }

        public DbSet<ApplicationLog> ApplicationLogs { get; set; }

        public DbSet<DataSource> DataSources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

}