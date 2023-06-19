using Homies.Contracts;
using Homies.Data;
using Homies.Data.DataModels;
using Homies.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Homies.Services
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext context;

        public EventService(HomiesDbContext _context)
        {
            context = _context;
        }


        public async Task AddEventAsync(AddEventViewModel model,string orginiserId)
        {
            var events = new Event
			{        
				Name = model.Name,
				Description = model.Description,
				Start = model.Start,
				End = model.End,
				TypeId = model.TypeId,
                CreatedOn = DateTime.UtcNow,
                OrganiserId = orginiserId
            };

			await context.Events.AddAsync(events);
			await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<EventViewModel>> GetAllAsync()
        {
            var entity = await context.Events
                .Include(x => x.Organiser)
                .Include(x => x.Type)
                .ToListAsync();

            return entity
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start,
                    Organiser = e.Organiser.UserName,
                    Type = e.Type.Name
                });
        }

        public async Task<IEnumerable<EventViewModel>> GetJoinedAsync(string userId)
        {
            //var entity = await context.EventsParticipants
            //    .Where(x => x.HelperId == us)
            //   .Include(x => x.Event)
            //   .ThenInclude(x => new { x.Organiser,x.Type})
            //   .ToListAsync();

            var entity = await context.Events
               .Where(x => x.OrganiserId == userId)
               .Include(x => x.Organiser)
               .Include(x => x.Type)
               .ToListAsync();

            return entity
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start,
                    Organiser = e.Organiser.UserName,
                    Type = e.Type.Name
                });
        }

        public async Task<IEnumerable<Data.DataModels.Type>> GetTypesAsync()
        {
            return await context.Types.ToListAsync();
        }
    }
}
