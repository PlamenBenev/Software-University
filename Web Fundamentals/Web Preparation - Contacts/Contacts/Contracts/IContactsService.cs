using Contacts.Models;

namespace Contacts.Contracts
{
	public interface IContactsService
	{
		Task<IEnumerable<ContactViewModel>> GetAllAsync();
		Task AddContactAsync(AddContactViewModel contact);
		Task AddContactToTeamAsync(ContactViewModel contactViewModel, string userId);

		Task<IEnumerable<ContactViewModel>> GetTeamAsync(string userId);
		Task<ContactViewModel?> GetContactByIdAsync(int contactId);
	}
}
