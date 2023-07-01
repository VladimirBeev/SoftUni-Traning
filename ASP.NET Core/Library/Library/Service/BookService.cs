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
				})
				.ToListAsync();
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

        public async Task<IEnumerable<MineAllBookViewModel>> GetMyBooks(string userId)
        {
			return await dbContext.IdentityUserBooks
				.Where(ub => ub.CollectorId == userId)
				.Select(b => new MineAllBookViewModel
				{
					Id = b.Book.Id,
					Title = b.Book.Title,
					Author = b.Book.Author,
					Description = b.Book.Description,
					ImageUrl = b.Book.ImageUrl,
					Category = b.Book.Category.Name
				})
				.ToListAsync();
        }

        public async Task AddBookToCollections(string userId, BookViewModel book)
        {
			bool alreadyAdded = await dbContext.IdentityUserBooks
				.AnyAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

			if (!alreadyAdded)
			{
                var userBook = new IdentityUserBook
                {
                    BookId = book.Id,
                    CollectorId = userId
                };

                await dbContext.IdentityUserBooks.AddAsync(userBook);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<BookViewModel?> GetBookById(int id)
        {
			return  await dbContext.Books
				.Where(b => b.Id == id)
				.Select(b => new BookViewModel
				{
					Id= b.Id,
					Title = b.Title,
					Author = b.Author,
					Description = b.Description,
					ImageUrl = b.ImageUrl,
					Rating = b.Rating,
					CategoryId = b.CategoryId
				})
				.FirstOrDefaultAsync();
        }

        public async Task RemoveBookFromCollection(string userId, BookViewModel? book)
        {
			var bookkkk = await dbContext.IdentityUserBooks
				.FirstOrDefaultAsync(u => u.CollectorId == userId && u.BookId == book.Id);

			if (bookkkk != null)
			{
                dbContext.IdentityUserBooks.Remove(bookkkk);
				await dbContext.SaveChangesAsync();
            }
        }
    }
}
