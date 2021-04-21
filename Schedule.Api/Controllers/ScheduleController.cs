using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Schedule.Api.Dto;
using Schedule.Data;

namespace Schedule.Api.Controllers
{
    [ApiController]
    [Route("scheduler")]
    public class ScheduleController : ControllerBase
    {

        private readonly ScheduleContext _scheduleContext;
        public ScheduleController(ScheduleContext scheduleContext)
        {
            _scheduleContext = scheduleContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetSchedule()
        {
            var schedule = _scheduleContext.Schedule.ToList();
            return Ok(schedule);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchelude([FromBody] ScheduleDto scheduleDto)
        {
            Domain.Shedule.Schedule schedule = new Domain.Shedule.Schedule(scheduleDto.Name, scheduleDto.ScheduleEvents);
            _scheduleContext.Add(schedule);
            await _scheduleContext.SaveChangesAsync();
            return Ok();
        }
    }
}
