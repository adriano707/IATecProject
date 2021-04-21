using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Schedule.Api.Dto;
using Schedule.Data;
using Schedule.Domain;

namespace Schedule.Api.Controllers
{
    [ApiController]
    [Route("events")]
    public class EventController : ControllerBase
    {
        public EventController(ScheduleContext scheduleContext)
        {
            _scheduleContext = scheduleContext;
        }

        private readonly ScheduleContext _scheduleContext;

        [HttpGet]
        public async Task<IActionResult> GetEvent()
        {
            var @event = _scheduleContext.Event.ToList();
            return Ok(@event);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] EventDto eventDto)
        {

            if (eventDto.Type == EventType.EXCLUSIVE &&
                _scheduleContext.Event.Any(a => a.Type == EventType.EXCLUSIVE && a.Date == eventDto.Date))
                return Conflict("Eventos excluisivos na mesma data.");

            Event @event = new Event(eventDto.Name,
                eventDto.Type,
                eventDto.Date,
                eventDto.Local,
                eventDto.Paticipants,
                eventDto.Category
                );
            await _scheduleContext.SaveChangesAsync();
            return Ok(@event);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(Guid id, [FromBody] EventDto eventDto)
        {
            Event @event = _scheduleContext.Event.FirstOrDefault(a => a.Id == id);

            if (@event == null)
                return NotFound("Event does not exist. ");
            @event.UpdateEvent(eventDto.Name, eventDto.Type, eventDto.Date, eventDto.Local, eventDto.Paticipants, eventDto.Category);
            _scheduleContext.Update(@event);
            await _scheduleContext.SaveChangesAsync();
            return Ok(@event);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(Guid id, [FromBody] EventDto eventDto)
        {
            Event @event = _scheduleContext.Event.FirstOrDefault(a => a.Id == id);

            if (@event == null)
                return NotFound();
            _scheduleContext.Remove(@event);
            await _scheduleContext.SaveChangesAsync();
            return Ok();
        }
    }
}
