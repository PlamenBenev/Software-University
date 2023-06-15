using Library.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
	public class BookViewModel
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MinLength(10)]
		[MaxLength(50)]
		public string Title { get; set; } = null!;

		[Required]
		[MinLength(5)]
		[MaxLength(5000)]
		public string Description { get; set; } = null!;

		[Required]
		[MinLength(5)]
		[MaxLength(50)]
		public string Author { get; set; } = null!;

		[Required]
		public string ImageUrl { get; set; } = null!;

		[Required]
		[Precision(18, 2)]
		[Range(0.00, 10.00)]
		public decimal Rating { get; set; }

		[Range(1,int.MaxValue)]
		public int CategoryId { get; set; }
	}
}
