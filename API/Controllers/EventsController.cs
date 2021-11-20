using Appliction.Events;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EventsController : BaseAPIController
    {
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query{Id = id}));
        }
        [HttpPost]
        public async Task<IActionResult> CreateEvent(Event eventArgs)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Event = eventArgs }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditEvent(Guid id, Event eventArgs)
        {
            eventArgs.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Event = eventArgs }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id =id }));
        }

    }
}
