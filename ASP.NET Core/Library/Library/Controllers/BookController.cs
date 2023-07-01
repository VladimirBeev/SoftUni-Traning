using Library.Contractors;
using Library.Data.Models;
using Library.Models.Book;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
	public class BookController : BaseController
	{
		private readonly IBookService bookService;

		public BookController(IBookService bookService)
		{
			this.bookService = bookService;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			var model = await bookService.GetAllBooks();
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			 AddBookViewModel viewModel = await bookService.PullCategoriesBook();

			return View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddBookViewModel viewModel)
		{
			if (ModelState.IsValid == false)
			{
				return View(viewModel);
			}

			await bookService.AddBook(viewModel);

			return RedirectToAction(nameof(All));
		}


		[HttpGet]
		public async Task<IActionResult> Mine()
		{
			var model = await bookService.GetMyBooks(GetUserId());

			return View(model);
		}


		[HttpPost]
		public async Task<IActionResult> AddToCollection(int id)
		{
			var book = await bookService.GetBookById(id);

			if (book == null)
			{
				return RedirectToAction(nameof(All));
			}

			var userId = GetUserId();

			await bookService.AddBookToCollections(userId, book);

			return RedirectToAction(nameof(All));
		}

		[HttpPost]
		public async Task<IActionResult> RemoveFromCollection(int id)
		{
			var book = await bookService.GetBookById(id);

			var userId = GetUserId();

			await bookService.RemoveBookFromCollection(userId, book);

			return RedirectToAction(nameof(Mine));
		}

    }
}
