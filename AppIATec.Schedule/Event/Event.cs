using System;
using System.Reflection.Metadata;

namespace Schedule.Domain.Event
{
    public class Event
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public EventType Type { get; private set; }
        public DateTime Date { get; private set; }
        public string Local { get; private set; }
        public int Participants { get; private set; }
        public EventStatus Status { get; private set; }
       

        public Event(string name, EventType type, DateTime date, string local, int participants, EventStatus status)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentException(nameof(name));
            Type = type;
            Date = date;
            Local = local ?? throw new ArgumentException(nameof(local));
            Participants = participants;
            Status = status;

        }

        public void UpdateEvent(string name, EventType type, DateTime date, string local, int participants)
        {
            Name = name;
            Type = type;
            Date = date;
            Local = local;
            Participants = participants;
        }
    }
}
