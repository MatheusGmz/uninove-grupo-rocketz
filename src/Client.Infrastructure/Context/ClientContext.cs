using Login.Domain.Entities;
using Login.Domain.ValueObjects;
using Login.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Login.Infrastructure.Context
{
    public class ClientContext : DbContext
    {
        private readonly ConfigurationKeys _configurationKeys;

        public ClientContext(ConfigurationKeys configurationKeys)
        {
            _configurationKeys = configurationKeys;
        }
        public DbSet<Client> Accounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMapping());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(_configurationKeys.DbConnection);
            base.OnConfiguring(optionBuilder);
        }
    }
}
