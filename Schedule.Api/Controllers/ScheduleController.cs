﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Schedule.Api.Dto;
using Schedule.Data;
using Schedule.Domain.Event;

namespace Schedule.Api.Controllers
{
    [ApiController]
    [Route("schedules")]
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
                return Conflict("Evento já finalizado");

            schendule.AddEvent(@event);

            _scheduleContext.Update(schendule);

            await _scheduleContext.SaveChangesAsync();
            return Ok(@event);
        }


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
