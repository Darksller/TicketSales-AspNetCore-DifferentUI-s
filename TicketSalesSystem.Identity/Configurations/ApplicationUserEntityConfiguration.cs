using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSalesSystem.Identity.Entities;

namespace TicketSalesSystem.Identity.Configurations
{
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x=>x.FirstName).HasMaxLength(50);
        }
    }
}
