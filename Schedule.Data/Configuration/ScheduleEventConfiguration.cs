using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Domain.Event;
using Schedule.Domain.Shedule;

namespace Schedule.Data.Configuration
{
    class ScheduleEventConfiguration : IEntityTypeConfiguration<ScheduleEvent>
    {
        public void Configure(EntityTypeBuilder<ScheduleEvent> builder)
        {
            builder.HasKey(a => new {a.ScheduleId, a.EventId});
        }
    }
}
