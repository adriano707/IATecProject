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
        public int Paticipants { get; private set; }
        public EventStatus Status { get; set; }
       

        public Event(string name, EventType type, DateTime date, string local, int paticipants)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentException(nameof(name));
            Type = type;
            Date = date;
            Local = local ?? throw new ArgumentException(nameof(local));
            Paticipants = paticipants;

        }

        public void UpdateEvent(string name, EventType type, DateTime date, string local, int participants)
        {
            Name = name;
            Type = type;
            Date = date;
            Local = local;
            Paticipants = participants;
        }
    }
}
