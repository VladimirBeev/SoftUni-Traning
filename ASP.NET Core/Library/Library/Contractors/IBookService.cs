using Library.Models.Book;

namespace Library.Contractors
{
	public interface IBookService
	{
		Task<IEnumerable<AllBookViewModel>> GetAllBooks();
    }
}
