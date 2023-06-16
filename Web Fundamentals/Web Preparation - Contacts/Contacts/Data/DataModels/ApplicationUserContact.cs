﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Data.DataModels
{
	public class ApplicationUserContact
	{
		[Required]
		[ForeignKey(nameof(ApplicationUser))]
		public string ApplicationUserId { get; set; } = null!;

		public ApplicationUser ApplicationUser { get; set; }

		[Required]
		[ForeignKey(nameof(Contact))]
		public int ContactId { get; set; }

		public Contact Contact { get; set; }
	}
}
