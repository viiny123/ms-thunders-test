using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Thunders.Domain.AggregatesModel.TaskAggregate;

namespace Test.Thunders.Data.Configuration.Mappings;

[ExcludeFromCodeCoverage]
public class TaskListMap : IEntityTypeConfiguration<TaskList>
{
    public void Configure(EntityTypeBuilder<TaskList> builder)
    {
        builder.ToTable("TaskLists");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
               .ValueGeneratedOnAdd();

        builder.Property(e => e.Description)
            .HasMaxLength(150);

        builder.Property(e => e.Status);

        builder.Property(e => e.Status)
            .HasColumnName("Status")
            .HasConversion<string>()
            .HasDefaultValue(Status.Opened);

        builder.Property(e => e.CreateAt)
            .HasDefaultValueSql("(getdate())");
    }
}
