﻿using ChatApp.Models.Message;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
	public class ChatController : Controller
	{
		private static List<KeyValuePair<string,string>> messages = new List<KeyValuePair<string,string>>();

		[HttpGet]
		public IActionResult Show()
		{
			if (messages.Count() < 1)
			{
				return View(new ChatViewModel());
			}
			var chatModel = new ChatViewModel()
			{
				Messages = messages.Select(m => new MessageViewModel()
				{
					Sender = m.Key,
					MessageText = m.Value,
				})
				.ToList()
			};
			return View(chatModel);
		}

		[HttpPost]

		public IActionResult Send(ChatViewModel chatView)
		{
			var newMessage = chatView.CurrentMessage;
			messages.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.MessageText));


			return RedirectToAction("Show");
		}
	}
}
