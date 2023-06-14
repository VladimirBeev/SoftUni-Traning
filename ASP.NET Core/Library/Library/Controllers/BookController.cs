using Library.Contractors;
using Library.Models.Book;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
	public class BookController : BaseController
	{
		private readonly IBookService bookService;

		public BookController(IBookService bookService)
		{
			this.bookService = bookService;
		}

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
	}
}
