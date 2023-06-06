﻿using Microsoft.AspNetCore.Mvc;
using MVCIntroDemo.Models.Product;
using Newtonsoft.Json;
using System.Text.Json;

namespace MVCIntroDemo.Controllers
{
	public class ProductController : Controller
	{
		private IEnumerable<ProductViewModel> _products
			= new List<ProductViewModel>()
			{
				new ProductViewModel()
				{
					Id= 1,
					Name = "Cheese",
					Price = 7.00
				},
				new ProductViewModel()
				{
					Id= 2,
					Name = "Ham",
					Price = 5.50
				},
				new ProductViewModel()
				{
					Id= 3,
					Name = "Bread",
					Price = 1.50
				}
			};
		public IActionResult All()
		{
			return View(_products);
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult ById(int id) 
		{
			var product = _products.FirstOrDefault(x => x.Id == id);
			if (product == null)
			{
				return BadRequest();
			}
			return View(product);
		}
		public IActionResult AllAsJson()
		{
			var options = new JsonSerializerOptions
			{
				WriteIndented = true
			};
			return Json(_products, options);
		}
	}
}
