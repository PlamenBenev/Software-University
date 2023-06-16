
using Contacts.Contracts;
using Contacts.Data;
using Contacts.Data.DataModels;
using Contacts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Contacts.Services
{
	public class ContactsService : IContactsService
	{
		private readonly ContactsDbContext context;

		public ContactsService(ContactsDbContext _context)
		{
			context = _context;
		}

		// It's taken from the controller and it will add it to the database
		public async Task AddContactAsync(AddContactViewModel contact)
		{
			var entity = new Contact()
			{
				FirstName = contact.FirstName,
				LastName = contact.LastName,
				Email = contact.Email,
				Address = contact.Address,
				Website = contact.Website,
				PhoneNumber = contact.PhoneNumber,
			};

			await context.Contacts.AddAsync(entity);
			await context.SaveChangesAsync();
		}

		//
		public async Task AddContactToTeamAsync(ContactViewModel contactViewModel, string userId)
		{
			bool alreadyAdded = await context.ApplicationUsersContacts
				.AnyAsync(x => x.ApplicationUserId == userId && x.ContactId == contactViewModel.Id);

			if (!alreadyAdded)
			{
				var userContact = new ApplicationUserContact
				{
					ContactId = contactViewModel.Id,
					ApplicationUserId = userId,
				};

				await context.ApplicationUsersContacts.AddAsync(userContact);
				await context.SaveChangesAsync();
			}

		}

		public async Task<ContactViewModel?> GetContactByIdAsync(int contactId)
		{
			return await context.Contacts
				.Where(x => x.Id == contactId)
				.Select(x => new ContactViewModel()
				{
					Id = x.Id,
					FirstName = x.FirstName,
					LastName = x.LastName,
					Email = x.Email,
					Address = x.Address,
					Website = x.Website,
					PhoneNumber = x.PhoneNumber,
				})
				.FirstOrDefaultAsync(); ;
		}

		[HttpGet]
		public async Task<IEnumerable<ContactViewModel>> GetAllAsync()
		{
			var users = await context.Contacts.ToArrayAsync();

			return users.Select(x => new ContactViewModel()
			{
				FirstName = x.FirstName,
				LastName = x.LastName,
				Email = x.Email,
				Address = x.Address,
				Website = x.Website,
				PhoneNumber = x.PhoneNumber,
			});
		}

		[HttpGet]
		public async Task<IEnumerable<ContactViewModel>> GetTeamAsync(string userId)
		{
			return await context.ApplicationUsersContacts
				.Where(x => x.ApplicationUserId == userId)
				.Select(x => new ContactViewModel
				{
					FirstName = x.Contact.FirstName,
					LastName = x.Contact.LastName,
					Email = x.Contact.Email,
					Address = x.Contact.Address,
					Website = x.Contact.Website,
					PhoneNumber = x.Contact.PhoneNumber,
				}).ToListAsync();
		}
	}
}
