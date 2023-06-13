using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Library.Data.DataValidations.DataValidations.DataBookValidations;

namespace Library.Data.Models
{
	[Comment("Table for the book")]
	public class Book
	{
		[Comment("Id for the book")]
		[Key]
		public int Id { get; set; }

		[Comment("Title for the book")]
		[Required]
		[MaxLength(TitleMaxLength)]
		public string Title { get; set; } = null!;

		[Comment("Author for the book")]
		[Required]
		[MaxLength(AuthorMaxLength)]
		public string Author { get; set; } = null!;

		[Comment("Description for the book")]
		[Required]
		[MaxLength(DiscriptionMaxLength)]
		public string Description { get; set; } = null!;

		[Comment("Image for the book")]
		[Required(AllowEmptyStrings = false)]
		public string ImageUrl { get; set; } = null!;

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
		public Category Category { get; set; } = null!;

		public List<IdentityUserBook> UserBooks { get; set; } = null!;
    }
}
