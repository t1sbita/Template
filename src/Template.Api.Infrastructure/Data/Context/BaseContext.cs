using Microsoft.EntityFrameworkCore;
using Template.Api.Core.Util;

namespace Template.Api.Infrastructure.Data.Context
{
    public class BaseContext : DbContext
    {
        private const string SESSION_CONNECTION_STRING = "ConnectionString:DefaultConnection";
        private string _connectionString { get; set; }

        public BaseContext() : base()
        {
            _connectionString = SESSION_CONNECTION_STRING;
        }

        public BaseContext(string connectionString) : base()
        {
            _connectionString = connectionString;
        }

        public BaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (_connectionString == null)
            {
                _connectionString = SESSION_CONNECTION_STRING;
            }

            string connectionString = SecretsUtil.GetBanco();
            if (connectionString == null)
            {
                throw new Exception("ConnectionString -> não está definida no projeto");
            }

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(SecretsUtil.GetSchema());
        }

    }
}
