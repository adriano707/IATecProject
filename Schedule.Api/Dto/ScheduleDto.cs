using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Schedule.Domain;
using Schedule.Domain.Shedule;

namespace Schedule.Api.Dto
{
    public class ScheduleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ScheduleEvent> ScheduleEvents { get; set; }
    }
}
