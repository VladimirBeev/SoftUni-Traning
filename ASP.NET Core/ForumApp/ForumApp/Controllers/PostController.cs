using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.Models.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace ForumApp.Controllers
{
	public class PostController : Controller
	{
		private readonly ForumAppDbContext context;

        public PostController(ForumAppDbContext context)
        {
			this.context = context;
        }

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			var post = await context.Posts.FindAsync(id);

			context.Posts.Remove(post);
			await context.SaveChangesAsync();

			return RedirectToAction("All");
		}
		public async Task<IActionResult> All()
		{
			var posts = await context
				.Posts
				.Select(p => new PostViewModel()
				{
					Id = p.Id,
					Title = p.Title,
					Content = p.Content,
				})
				.ToListAsync();

			return View(posts);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var post = await context.Posts.FindAsync(id);

			return View(new PostViewModel()
			{
				Title = post.Title,
				Content = post.Content,
			});
		}

		[HttpPost]

		public async Task<IActionResult> Edit(int id, PostViewModel model)
		{
			var post = await context.Posts.FindAsync(id);

			post.Title = model.Title;
			post.Content = model.Content;

			await context.SaveChangesAsync();

			return RedirectToAction("All");
		}

		[HttpGet]
		public async Task<IActionResult> Add() => View();

		[HttpPost]
		public async Task<IActionResult> Add(PostViewModel model)
		{
			var post = new Post()
			{
				Id = model.Id,
				Title = model.Title,
				Content = model.Content,
			};
			await context.AddAsync(post);
			await context.SaveChangesAsync();
			return RedirectToAction("All");
		}
        public IActionResult Index()
		{
			return View();
		}
	}
}
