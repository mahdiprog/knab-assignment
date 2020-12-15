using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Triskele.Config.Domain;

namespace Triskele.Config.Dal.Configurations
{
    public class ServerConfig: IEntityTypeConfiguration<Server>
    {
        public void Configure(EntityTypeBuilder<Server> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.Property(e=>e.ServerId).UseIdentityColumn();
            builder.Property(e=>e.Address).HasMaxLength(45);
        }
    }
}
