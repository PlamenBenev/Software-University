using Microsoft.AspNetCore.Identity;

namespace Contacts.Data.DataModels
{
	public class ApplicationUser : IdentityUser
	{
		public ICollection<ApplicationUserContact> ApplicationUsersContacts{ get; set; } = new List<ApplicationUserContact>();

	}
}
