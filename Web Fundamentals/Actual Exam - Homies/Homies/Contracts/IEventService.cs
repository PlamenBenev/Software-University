using Homies.Models;

namespace Homies.Contracts
{
    public interface IEventService
    {
        Task AddEventAsync(AddEventViewModel model, string organiserId);
        Task AddToJoinedAsync(string userId, EventViewModel book);
        Task<bool> EditEventAsync(EditViewModel model);
        Task<IEnumerable<EventViewModel>> GetAllAsync();
        Task<EditViewModel> GetEditByIdAsync(int id);
        Task<DetailsViewModel> GetDetailsByIdAsync(int id);
        Task<EventViewModel?> GetEventByIdAsync(int id);
        Task<IEnumerable<EventViewModel>> GetJoinedAsync(string userId);
        Task<IEnumerable<Data.DataModels.Type>> GetTypesAsync();
        Task RemoveFromJoinedAsync(string userId, int eventId);

        Task<bool> AddedEventAsync(string userId, int eventModelId);
    }
}
