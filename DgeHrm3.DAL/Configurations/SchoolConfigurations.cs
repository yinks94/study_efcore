using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DgeHrm3.DAL.Model;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DgeHrm3.DAL.Configurations;

public class SchoolConfiguration : IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> builder)
    {
        builder.HasOne<School>(s => s.Parent);

        builder.Property(s => s.CanTransfer)
            .HasConversion<string>(new BoolToStringConverter("N", "Y"));

        builder.Property(s => s.Enable)
            .HasConversion<string>(new BoolToStringConverter("N", "Y"));

        builder.Property(s => s.HasChild)
            .HasConversion<string>(new BoolToStringConverter("N", "Y"));

        builder.Property( s=>s.Kind)
            .HasConversion(
                v => v.ToString(),
                v => (SchoolKind)Enum.Parse(typeof(SchoolKind), v));

        builder.Property(s => s.Establish)
            .HasConversion(
                v => v.ToString(),
                v => (SchoolEstablish)Enum.Parse(typeof(SchoolEstablish), v));
    }
}