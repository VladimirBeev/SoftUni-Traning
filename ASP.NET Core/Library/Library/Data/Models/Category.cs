using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Library.Data.DataValidations.DataValidations.DataCategoryValidations;

namespace Library.Data.Models
{
	[Comment("Table for Category of Books")]
	public class Category
	{
		[Comment("Primary key")]
		[Key]
		public int Id { get; set; }

		[Comment("Name of the category")]
		[Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		[Comment("List of Book")]
		public List<Book> Book { get; set; } = null!;
    }
}