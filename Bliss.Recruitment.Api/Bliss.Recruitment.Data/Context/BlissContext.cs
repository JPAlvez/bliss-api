using Bliss.Recruitment.Data.Context.Mappings;
using Bliss.Recruitment.Entities;
using System.Data.Entity;

namespace Bliss.Recruitment.Data.Context
{
    public class BlissContext : DbContext
    {
        public BlissContext() : base("DbContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
            Database.SetInitializer<BlissContext>(null);
        }

        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new QuestionMapping());
            modelBuilder.Configurations.Add(new QuestionChoiceMapping());
        }
    }
}
