using Library.Contractors;
using Library.Data;
using Library.Data.Models;
using Library.Models.Book;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
{
	public class BookService : IBookService
	{
		private readonly LibraryDbContext dbContext;

		public BookService(LibraryDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<AllBookViewModel>> GetAllBooks()
		{
			return await dbContext.Books
				.Select(b => new AllBookViewModel
				{
					Id = b.Id,
					Title = b.Title,
					Author = b.Author,
					Rating = b.Rating,
					ImageUrl = b.ImageUrl,
					Category = b.Category.Name
				}).ToListAsync();
		}
	}
}
