using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
	public class AddBookViewModel
	{
		[Required]
		[MinLength(10)]
		[MaxLength(50)]
		public string Title { get; set; } = null!;


		[Required]
		[MinLength(5)]
		[MaxLength(50)]
		public string Author { get; set; } = null!;

		[Required]
		[MinLength(5)]
		[MaxLength(5000)]
		public string Description { get; set; } = null!;

		[Required]
		public string Url { get; set; } = null!;

		[Required]
		[Precision(18, 2)]
		[Range(0.00, 10.00)]
		public decimal Rating { get; set; }

		[Required]
		public int CategoryId { get; set; }

		public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
	}
}
