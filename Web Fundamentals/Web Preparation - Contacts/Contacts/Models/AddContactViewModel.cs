using System.ComponentModel.DataAnnotations;

namespace Contacts.Models
{
    public class AddContactViewModel
    {
		[Required]
		[MinLength(2)]
		[MaxLength(50)]
		public string FirstName { get; set; } = null!;

		[Required]
		[MinLength(5)]
		[MaxLength(50)]
		public string LastName { get; set; } = null!;

		[Required]
		[MinLength(10)]
		[MaxLength(60)]
		public string Email { get; set; } = null!;

		[Required]
		[MinLength(10)]
		[MaxLength(13)]
		[RegularExpression("^(?:\\+359|0)\\s?\\d{3}(?:[-\\s]?\\d{2}){3}$")]
		public string PhoneNumber { get; set; } = null!;

		public string Address { get; set; } = null!;

		[Required]
		[RegularExpression("^www\\.[a-zA-Z0-9-]+\\.[bB][gG]$")]
		public string Website { get; set; }
	}
}
