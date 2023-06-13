using Library.Contractors;
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
	}
}
