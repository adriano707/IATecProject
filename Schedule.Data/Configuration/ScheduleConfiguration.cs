using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Schedule.Data.Configuration
{
    class ScheduleConfiguration : IEntityTypeConfiguration<Domain.Schedule.Schedule>
    {
        public void Configure(EntityTypeBuilder<Domain.Schedule.Schedule> builder)
        {
            builder.HasKey(a => a.Id);

            builder
                .HasMany(e => e.ScheduleEvents);

            var navigation =
                builder.Metadata.FindNavigation(nameof(Domain.Schedule.Schedule.ScheduleEvents));

            //EF access the OrderItem collection property through its backing field
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
