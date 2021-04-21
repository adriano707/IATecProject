using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Schedule.Data.Configuration
{
    class ScheduleConfiguration : IEntityTypeConfiguration<Domain.Shedule.Schedule>
    {
        public void Configure(EntityTypeBuilder<Domain.Shedule.Schedule> builder)
        {
            builder.HasKey(a => a.Id);
        }
    }
}
