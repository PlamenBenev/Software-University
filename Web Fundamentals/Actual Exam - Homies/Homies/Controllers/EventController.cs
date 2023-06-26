using Homies.Contracts;
using Homies.Models;
using Homies.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService eventService;

        public EventController(IEventService _eventService)
        {
            eventService = _eventService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await eventService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddEventViewModel()
            {
                Types = await eventService.GetTypesAsync(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await eventService.AddEventAsync(model,GetUserId());

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditViewModel contact = await eventService.GetEditByIdAsync(id);
            if (contact == null)
            {
                // Handle the case where the contact is not found

            }

            return View(contact);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await eventService.EditEventAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var eventModel = await eventService.GetEventByIdAsync(id);

            if (eventModel == null)
            {
                return RedirectToAction(nameof(All));
            }

            var userId = GetUserId();

            await eventService.AddToJoinedAsync(userId, eventModel);

            return RedirectToAction(nameof(Joined));
        }


        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var model = await eventService.GetJoinedAsync(GetUserId());

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
           // EventViewModel? eventModel = await eventService.GetEventByIdAsync(id);

            await eventService.RemoveFromJoinedAsync(GetUserId(), id);

            return RedirectToAction(nameof(Joined));
        }
    }
}
