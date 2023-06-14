using Library.Models.Book;

namespace Library.Contractors
{
	public interface IBookService
	{
        Task AddBook(AddBookViewModel viewModel);
        Task<IEnumerable<AllBookViewModel>> GetAllBooks();

		Task<AddBookViewModel> PullCategoriesBook();

    }
}
