using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Schedule.Domain
{
    public class Event
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public EventType Type { get; private set; }
        public DateTime Date { get; private set; }
        public string Local { get; private set; }
        public int Paticipants { get; private set; }
        public Category Category { get; private set; }
       

        public Event(string name, EventType type, DateTime date, string local, int paticipants, Category category)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentException(nameof(name));
            Type = type;
            Date = date;
            Local = local ?? throw new ArgumentException(nameof(local));
            Paticipants = paticipants;
            Category = category;

        }

        public void UpdateEvent(string name, EventType type, DateTime date, string local, int participants, Category category)
        {
            Name = name;
            Type = type;
            Date = date;
            Local = local;
            Paticipants = participants;
            Category = category;
        }
    }
}
