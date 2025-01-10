
namespace SurveyBasket.EnitiesConfigration;

public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(p=>p.FirstName).HasMaxLength(20);
        builder.Property(p=>p.LastName).HasMaxLength(20);
    }
}
