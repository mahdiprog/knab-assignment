using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Triskele.Config.Application.Interfaces;
using Triskele.Config.Domain;

namespace Triskele.Config.Infra.Persistence
{
    public partial class ConfigModel : DbContext, IConfigModel
    {
        public ConfigModel() : base()
        {
        }

        public ConfigModel(DbContextOptions<ConfigModel> options) : base(options)
        {
        }

        public virtual DbSet<Server> Servers { get; set; }
        public virtual DbSet<Configuration> Configurations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException(nameof(modelBuilder));

            modelBuilder.HasDefaultSchema("cfg");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConfigModel).Assembly);
            // Seed data
            modelBuilder.Seed();
        }

    }
}
