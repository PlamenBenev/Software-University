using System.ComponentModel.DataAnnotations;

namespace Contacts.Models
{
	public class RegisterViewModel
	{
		[Required]
		[MinLength(5)]
		[MaxLength(20)]
		public string UserName { get; set; } = null!;

		[Required]
		[EmailAddress]
		[MinLength(10)]
		[MaxLength(60)]
		public string Email { get; set; } = null!;


		[Required]
		[MinLength(5)]
		[MaxLength(20)]
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;

		[Compare(nameof(Password))]
		[DataType(DataType.Password)]
		[Required]
		public string ConfirmPassword { get; set; } = null!;

	}
}
