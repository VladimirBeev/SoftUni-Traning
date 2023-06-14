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

		public async Task<AddBookViewModel> PullCategoriesBook()
		{
			var categories = await dbContext.Category
				.Select(c => new CategoryViewModel
				{
					Id = c.Id,
					Name = c.Name,
				})
				.ToListAsync();
			var model = new AddBookViewModel
			{
				Category = categories
			};
			return model;
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

        public async Task AddBook(AddBookViewModel viewModel)
        {
			Book book = new Book
			{
				Id = viewModel.Id,
				Title = viewModel.Title,
				Author = viewModel.Author,
				Rating = viewModel.Rating,
				Description = viewModel.Description,
				ImageUrl = viewModel.Url,
				CategoryId = viewModel.CategoryId
			};

			await dbContext.Books.AddAsync(book);
			await dbContext.SaveChangesAsync();
        }
    }
}
