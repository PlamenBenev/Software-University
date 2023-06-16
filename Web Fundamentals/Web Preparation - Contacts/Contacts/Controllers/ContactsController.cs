using Contacts.Contracts;
using Contacts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Contacts.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly IContactsService contactService;

        public ContactsController(IContactsService _contactService)
        {
            contactService = _contactService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await contactService.GetAllAsync();

            return View(model);
        }

        // It will visualize it
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddContactViewModel();

            return View(model);
        }

        // It will take the input from the user and pass it to the service
        [HttpPost]
		public async Task<IActionResult> Add(AddContactViewModel addContactViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(addContactViewModel);
			}

			try
			{
				await contactService.AddContactAsync(addContactViewModel);

				return RedirectToAction(nameof(All));
			}
			catch (Exception)
			{
				ModelState.AddModelError("", "Something went wrong");

				return View(addContactViewModel);
			}
		}

		[HttpGet]
		public async Task<IActionResult> Team()
		{
			var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

			var model = await contactService.GetTeamAsync(userId);

			return View("Team", model);
		}

		[HttpPost]
		public async Task<IActionResult> AddToTeam(int contactId)
		{
			var contact = await contactService.GetContactByIdAsync(contactId);

			if (contact == null)
			{
				return RedirectToAction(nameof(All));
			}

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			await contactService.AddContactToTeamAsync(contact, userId);

			return RedirectToAction(nameof(All));
		}


	}
}
