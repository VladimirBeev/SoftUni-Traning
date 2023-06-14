using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Library.Data.DataValidations.DataValidations.DataCategoryValidations;

namespace Library.Models.Book
{
	public class CategoryViewModel
	{
		[Comment("Primary key")]
		[Key]
		public int Id { get; set; }

		[Comment("Name of the category")]
		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;
	}
}