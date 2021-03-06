using System;
using System.Collections.Generic;
using Schedule.Domain.Shedule;

namespace Schedule.Domain.Schedule
{
    public class Schedule
    {
        private readonly List<ScheduleEvent> _scheduleEvents;
        public Guid Id { get; private set; }

        /// <summary>
        /// Name of the schedule
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// return a list with shcedule's event
        /// </summary>
        public IReadOnlyCollection<ScheduleEvent> ScheduleEvents => _scheduleEvents;
        
        
        public Schedule()
        {
            _scheduleEvents = new List<ScheduleEvent>();
        }

        public Schedule(string name)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentException(nameof(name));
            _scheduleEvents = new List<ScheduleEvent>();
        }

        public void AddEvent(Event.Event @event)
        {
            ScheduleEvent e = new ScheduleEvent(@event, this);
            _scheduleEvents.Add(e);
        }
    }
}
