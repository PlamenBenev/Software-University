using Homies.Models;

namespace Homies.Contracts
{
    public interface IEventService
    {
        Task AddEventAsync(AddEventViewModel model, string organiserId);
        Task<IEnumerable<EventViewModel>> GetAllAsync();
        Task<IEnumerable<EventViewModel>> GetJoinedAsync(string userId);
        Task<IEnumerable<Data.DataModels.Type>> GetTypesAsync();
    }
}
