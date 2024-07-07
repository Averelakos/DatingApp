using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure;

public abstract class BaseEntityConfiguration
{
    public BaseEntityConfiguration(){}

    public void ConfigurationBase<TEntity>(EntityTypeBuilder<TEntity> entity) where TEntity: BaseEntity
    {
        // Identifier
        entity.HasKey(x => x.Id);
        // Created
        entity.Property(x => x.Created)
            .HasColumnType("datetime2(7)")
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");
         // Last Updated
        entity.Property(e => e.LastUpdated)
            .HasColumnType("datetime2(7)")
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");

        // Created by 
        entity.HasOne(e => e.CreatedBy)
            .WithMany()
            .HasForeignKey(e => e.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

        // Last updated by 
        entity.HasOne(e => e.LastUpdatedBy)
            .WithMany()
            .HasForeignKey(e => e.LastUpdatedById)
            .OnDelete(DeleteBehavior.Restrict);
            }
}
