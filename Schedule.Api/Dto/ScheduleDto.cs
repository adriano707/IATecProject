﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schedule.Domain;

namespace Schedule.Api.Dto
{
    public class ScheduleDto
    {
        public string Name { get; set; }
        public List<ScheduleEvent> ScheduleEvents { get; set; }
    }
}