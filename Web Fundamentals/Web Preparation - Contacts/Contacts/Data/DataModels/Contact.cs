using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Data.DataModels
{
	public class Contact
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string FirstName { get; set; } = null!;

		[Required]
		[MaxLength(50)]
		public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(60)]
        public string Email { get; set; } = null!;

        [Required]
		[RegularExpression("^(?:\\+359|0)\\s?\\d{3}(?:[-\\s]?\\d{2}){3}$")]
		public string PhoneNumber { get; set; } = null!;

		public string Address { get; set; } = null!;

		[Required]
		[RegularExpression("^www\\.[a-zA-Z0-9-]+\\.[bB][gG]$")]
		public string Website { get; set; }

		public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; } = new List<ApplicationUserContact>();

	}
}
