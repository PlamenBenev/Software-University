using Library.Contracts;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
	public class BookController : BaseController
	{
		private readonly IBookService bookService;

        public BookController(IBookService _bookService)
        {
            bookService = _bookService;
        }

        public async Task<IActionResult> All()
		{
			var model = await bookService.GetAllBooksAsync();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			AddBookViewModel viewModel = await bookService.GetAddNewBookAsync();

			return View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddBookViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await bookService.AddBookAsync(model);

			return RedirectToAction("All","Book");
		}
		public async Task<IActionResult> Mine()
		{
			var model = await bookService.GetMyBooksAsync(GetUserId());

			return View(model);
		}

		public async Task<IActionResult> AddToCollection(int id)
		{
			var book = await bookService.GetBookByIdAsync(id);

			if (book == null)
			{
				return RedirectToAction("All", "Book");
			}

			var userId = GetUserId();

			await bookService.AddToCollectionAsync(userId, book);

			return RedirectToAction("All", "Book");
		}

		public async Task<IActionResult> RemoveFromCollection(int id)
		{
			var book = await bookService.GetBookByIdAsync(id);

			if (book == null)
			{
				return RedirectToAction("Mine","Book");
			}

			var userId = GetUserId();

			await bookService.RemoveFromCollectionAsync(userId,book);

			return RedirectToAction("Mine", "Book");

		}
	}
}
