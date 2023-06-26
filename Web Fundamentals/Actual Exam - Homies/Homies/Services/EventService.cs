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


        public async Task AddEventAsync(AddEventViewModel model, string orginiserId)
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

        public async Task AddToJoinedAsync(string userId, EventViewModel eventModel)
        {
            bool alreadyAdded = await context.EventsParticipants
                .AnyAsync(x => x.HelperId == userId && x.EventId == eventModel.Id);

            if (!alreadyAdded)
            {
                var userEvent = new EventParticipant
                {
                    EventId = eventModel.Id,
                    HelperId = userId,
                };

                await context.EventsParticipants.AddAsync(userEvent);
                await context.SaveChangesAsync();
            }

        }

        public async Task<bool> EditEventAsync(EditViewModel model)
        {
            var existingEvent = await context.Events.FindAsync(model.Id);

            if (existingEvent == null)
            {
                return false;
            }

            existingEvent.Name = model.Name;
            existingEvent.Start = model.Start;
            existingEvent.End = model.End;
            existingEvent.Description = model.Description;
            existingEvent.TypeId = model.TypeId;

            context.Entry(existingEvent).CurrentValues.SetValues(model);
            await context.SaveChangesAsync();

            return true;
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

        public async Task<EditViewModel> GetEditByIdAsync(int id)
        {
            var types = await context.Types
                        .Select(x => new TypeViewModel
                        {
                            Id = x.Id,
                            Name = x.Name
                        }).ToListAsync();

            return await context.Events
                    .Where(x => x.Id == id)
                    .Select(e => new EditViewModel()
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Description = e.Description,
                        Start = e.Start,
                        End = e.End,
                        Types = types,
                        TypeId = e.TypeId
                    })
                    .FirstOrDefaultAsync();
        }

        public async Task<EventViewModel?> GetEventByIdAsync(int id)
        {
            return await context.Events
                    .Where(x => x.Id == id)
                    .Select(e => new EventViewModel()
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Start = e.Start,
                        Organiser = e.Organiser.UserName,
                        Type = e.Type.Name,
                    })
                    .FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<EventViewModel>> GetJoinedAsync(string userId)
        {
            return await context.EventsParticipants
                .Where(x => x.HelperId == userId)
                .Select(e => new EventViewModel
                {
                    Id = e.Event.Id,
                    Name = e.Event.Name,
                    Start = e.Event.Start,
                    Organiser = e.Event.Organiser.UserName,
                    Type = e.Event.Type.Name,
                }).ToListAsync();

        }

        public async Task<IEnumerable<Data.DataModels.Type>> GetTypesAsync()
        {
            return await context.Types.ToListAsync();
        }

        public async Task RemoveFromJoinedAsync(string userId, int eventId)
        {
            EventParticipant? eventParticipant = await context.EventsParticipants
                  .Where(x => x.HelperId == userId && x.EventId == eventId).FirstOrDefaultAsync();

            if (eventParticipant != null)
            {
                context.EventsParticipants.Remove(eventParticipant);
                await context.SaveChangesAsync();
            }
        }
    }
}
