using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Seventh.Desafio.Infra.Configurations;

public class ServerMappingConfig : IEntityTypeConfiguration<ServerModel>
{
    public void Configure(EntityTypeBuilder<ServerModel> builder)
    {
        builder.ToTable("server");
        builder.HasKey(x => x.Uid);
        builder.Property(x => x.Uid).HasDefaultValueSql("newid()").HasColumnName("id");
        builder.Property(x => x.Name).HasMaxLength(160).HasColumnName("name");
        builder.Property(x => x.IpAddress).HasMaxLength(15).HasColumnName("ip_address");
        builder.Property(x => x.Port).HasMaxLength(6).HasColumnName("port");
    }
}
