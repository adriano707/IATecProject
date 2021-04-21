using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Domain
{
    public class Schedule
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<ScheduleEvent> ScheduleEvents { get; private set; }

        public Schedule(string name, List<ScheduleEvent> scheduleEvents)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentException(nameof(name));
            ScheduleEvents = scheduleEvents;
        }
    }
}
