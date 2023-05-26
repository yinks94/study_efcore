using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DgeHrm3.DAL.Model;

namespace DgeHrm3.DAL.Configurations;

public class QuotaConfigurations : IEntityTypeConfiguration<Quota>
{

    public void Configure(EntityTypeBuilder<Quota> builder)
    {
        builder.HasOne<School>( e => e.School);
        builder.HasOne<Subject>( e => e.Subject);
    }
         
}