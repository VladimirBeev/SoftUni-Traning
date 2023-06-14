using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Library.Data.DataValidations.DataValidations.DataBookValidations;

namespace Library.Models.Book
{
	public class AddBookViewModel
	{
		[Comment("Id for the book")]
		[Key]
		public int Id { get; set; }

		[Comment("Title for the book")]
		[Required]
		[StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
		public string Title { get; set; } = null!;

		[Comment("Author for the book")]
		[Required]
		[StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
		public string Author { get; set; } = null!;

		[Comment("Description for the book")]
		[Required]
		[StringLength(DiscriptionMaxLength, MinimumLength = DiscriptionMinLength)]
		public string Description { get; set; } = null!;

		[Comment("Image for the book")]
		[Required(AllowEmptyStrings = false)]
		public string Url { get; set; } = null!;

		[Comment("Rating for the book")]
		[Required]
		[Column(TypeName = "decimal(18,2)")]
		[Range(RatingMinLength, RatingMaxLength)]
		public decimal Rating { get; set; }

		[Comment("CategoryId for the book")]
		[Required]
		public int CategoryId { get; set; }

		[Comment("Category of the book")]
		[ForeignKey(nameof(CategoryId))]
		public IEnumerable<CategoryViewModel> Category { get; set; } = new List<CategoryViewModel>();
	}
}
