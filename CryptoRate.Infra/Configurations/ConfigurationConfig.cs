using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Triskele.Config.Domain;

namespace Triskele.Config.Dal.Configurations
{
    public class ConfigurationConfig : IEntityTypeConfiguration<Configuration>
    {
        public void Configure(EntityTypeBuilder<Configuration> builder)
        {

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            

            builder.HasKey(c => new { c.ConfigKey, c.ApiProviderName });

            builder.HasIndex(b => b.ApiProviderName);

            builder.Property(e=>e.ConfigKey).HasMaxLength(100);
            builder.Property(e=>e.Value).HasMaxLength(512);
            builder.Property(e=>e.ApiProviderName).HasMaxLength(128);
        }
    }
}
