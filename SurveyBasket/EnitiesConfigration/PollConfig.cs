using System.Reflection.Emit;

namespace SurveyBasket.EnitiesConfigration;

public class PollConfig : IEntityTypeConfiguration<Poll>
{
    public void Configure(EntityTypeBuilder<Poll> builder)
    {
        builder.HasIndex(p => p.Title).IsUnique();
        builder.Property(p => p.Title).HasMaxLength(20);


    }
}
