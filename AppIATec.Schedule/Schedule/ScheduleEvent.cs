using System;

namespace Schedule.Domain.Shedule
{
    public class ScheduleEvent
    {
        
        public Event.Event Event { get; private set; }
        public Schedule.Schedule Schedule { get; private set; }

        public Guid ScheduleId { get; set; }
        public Guid EventId { get; set; }

        public ScheduleEvent() { }

        public ScheduleEvent(Event.Event @event, Schedule.Schedule schedule)
        {
            EventId = @event.Id;
            ScheduleId = schedule.Id;
            Event = @event;
            Schedule = schedule;
        }
    }
}
