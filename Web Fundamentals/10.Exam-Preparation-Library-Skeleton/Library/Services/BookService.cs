using Library.Contracts;
using Library.Data;
using Library.Data.DataModels;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Library.Services
{
	public class BookService : IBookService
	{
		private readonly LibraryDbContext context;

		public BookService(LibraryDbContext _context)
		{
			context = _context;
		}


		public async Task<IEnumerable<AllBooksViewModel>> GetAllBooksAsync()
		{
			return await context.Books
				.Select(book => new AllBooksViewModel()
				{
					Id = book.Id,
					Title = book.Title,
					Author = book.Author,
					ImageUrl = book.ImageUrl,
					Rating = book.Rating,
					Category = book.Category.Name
				})
				.ToListAsync();
		}
		public async Task AddToCollectionAsync(string userId, BookViewModel bookViewModel)
		{
			bool alreadyAdded = await context.IdentityUsersBooks
				.AnyAsync(x => x.CollectorId == userId && x.BookId == bookViewModel.Id);

			if (!alreadyAdded)
			{
				var userBook = new IdentityUserBook
				{
					BookId = bookViewModel.Id,
					CollectorId = userId,
				};

				await context.IdentityUsersBooks.AddAsync(userBook);
				await context.SaveChangesAsync();
			}

		}

		public async Task<BookViewModel?> GetBookByIdAsync(int id)
		{
			return await context.Books
					.Where(x => x.Id == id)
					.Select(book => new BookViewModel()
					{
						Id = book.Id,
						Title = book.Title,
						Author = book.Author,
						Description = book.Description,
						ImageUrl = book.ImageUrl,
						Rating = book.Rating,
						CategoryId = book.CategoryId
					})
					.FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<AllBooksViewModel>> GetMyBooksAsync(string userId)
		{
			return await context.IdentityUsersBooks
				.Where(x => x.CollectorId == userId)
				.Select(x => new AllBooksViewModel
				{
					Id = x.BookId,
					Title = x.Book.Title,
					Author = x.Book.Author,
					ImageUrl = x.Book.ImageUrl,
					Description = x.Book.Description,
					Category = x.Book.Category.Name
				}).ToListAsync();
		}

		public async Task RemoveFromCollectionAsync(string userId, BookViewModel book)
		{
			var userBook = await context.IdentityUsersBooks
				.FirstOrDefaultAsync(x => x.CollectorId == userId && x.BookId == book.Id);

			if (userBook != null)
			{
				context.IdentityUsersBooks.Remove(userBook);
				await context.SaveChangesAsync();
			}
		}

		public async Task<AddBookViewModel> GetAddNewBookAsync()
		{
			var categories = await context.Categories
				.Select(x => new CategoryViewModel
				{
					Id = x.Id,
					Name = x.Name
				}).ToListAsync();

			var model = new AddBookViewModel
			{
				Categories = categories
			};

			return model;
		}

		public async Task AddBookAsync(AddBookViewModel model)
		{
			Book book = new Book
			{
				Title = model.Title,
				Author = model.Author,
				Description = model.Description,
				ImageUrl = model.Url,
				Rating = model.Rating,
				CategoryId = model.CategoryId,
			};

			await context.Books.AddAsync(book);
			await context.SaveChangesAsync();
		}
	}
}
