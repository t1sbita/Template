using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Template.Worker.Utils;

namespace Template.Worker.Data.Context
{
    public class TemplateContext : BaseContext
    {
        public TemplateContext(DbContextOptions<TemplateContext> options) : base(options)
        {
        }

        public TemplateContext() : base()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string schema = SecretsUtil.GetSchema();
            modelBuilder.HasDefaultSchema(schema);

            var typesToRegister = from t in Assembly.GetExecutingAssembly().GetTypes()
                                  where !string.IsNullOrWhiteSpace(t.Namespace) &&
                                  t.GetInterfaces().Any(i => i.Name == typeof(IEntityTypeConfiguration<>).Name && i.Namespace == typeof(IEntityTypeConfiguration<>).Namespace)
                                  select t;

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
