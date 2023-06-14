using Library.Data.Models;
using Library.Models.Book;

namespace Library.Contractors
{
    public interface IBookService
	{
        Task AddBook(AddBookViewModel viewModel);
        Task AddBookToCollections(string userId, BookViewModel book);
        Task<IEnumerable<AllBookViewModel>> GetAllBooks();
        Task<BookViewModel?> GetBookById(int id);
        Task<IEnumerable<MineAllBookViewModel>> GetMyBooks(string userId);
        Task<AddBookViewModel> PullCategoriesBook();
        Task RemoveBookFromCollection(string userId, BookViewModel? book);
    }
}
