using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schedule.Api.Dto;
using Schedule.Data;
using Schedule.Domain.Event;

namespace Schedule.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("schedules")]
    public class ScheduleController : ControllerBase
    {

        private readonly ScheduleContext _scheduleContext;
        public ScheduleController(ScheduleContext scheduleContext)
        {
            _scheduleContext = scheduleContext;
        }

        /// <summary>
        /// Get all schendules
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSchedule()
        {
            var schedule = _scheduleContext.Schedule.ToList();
            return Ok(schedule);
        }

        /// <summary>
        /// Method for adding an existing event to a calendar.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eventDtoId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/events")]
        public async Task<IActionResult> AddEvent([FromRoute] Guid id, [FromBody] EventDtoId eventDtoId)
        {

            var schendule = _scheduleContext.Schedule.FirstOrDefault(e => e.Id == id);

            if (schendule == null)
                return NotFound("Schedule not found");

            var @event = _scheduleContext.Event.FirstOrDefault(a => a.Id == eventDtoId.Id);

            if (@event == null)
                return NotFound("Event not found");

            if (@event.Status == EventStatus.FINISHED)
                return Conflict("Event already finished");

            schendule.AddEvent(@event);

            _scheduleContext.Update(schendule);

            await _scheduleContext.SaveChangesAsync();
            return Ok(@event);

        }


        /// <summary>
        /// Method that takes an event on the schedule.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/events")]
        public async Task<IActionResult> GetEventBySchedule([FromRoute] Guid id)
        {

            var events = _scheduleContext.ScheduleEvent
                .Where(e => e.ScheduleId == id)
                .Select(e => e.Event)
                .ToList();
            return Ok(events);
        }


        /// <summary>
        /// Method for creating an schedule
        /// </summary>
        /// <param name="scheduleDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateSchedule([FromBody] ScheduleDto scheduleDto)
        {
            Domain.Schedule.Schedule schedule = new Domain.Schedule.Schedule(scheduleDto.Name);
            _scheduleContext.Add(schedule);
            await _scheduleContext.SaveChangesAsync();
            return Ok();
        }
    }
}
