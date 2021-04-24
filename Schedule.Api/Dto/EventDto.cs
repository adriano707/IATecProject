using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schedule.Domain;
using Schedule.Domain.Event;

namespace Schedule.Api.Dto
{
    public class EventDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EventType Type { get;  set; }
        public DateTime Date { get; set; }
        public string Local { get; set; }
        public int Paticipants { get; set; }

    }
}
