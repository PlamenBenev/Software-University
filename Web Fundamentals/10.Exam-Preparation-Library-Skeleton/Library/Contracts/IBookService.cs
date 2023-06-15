using Library.Models;

namespace Library.Contracts
{
	public interface IBookService
	{
		Task<IEnumerable<AllBooksViewModel>> GetAllBooksAsync();
		Task<IEnumerable<AllBooksViewModel>> GetMyBooksAsync(string userId);

		Task<BookViewModel?> GetBookByIdAsync(int id);

		Task AddToCollectionAsync(string userId, BookViewModel bookViewModel);
		Task RemoveFromCollectionAsync(string userId, BookViewModel book);
		Task<AddBookViewModel> GetAddNewBookAsync();
		Task AddBookAsync(AddBookViewModel model);
	}
}
