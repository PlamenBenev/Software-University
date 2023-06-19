using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.DataModels
{
    public class EventParticipant
    {
        [Required]
        [ForeignKey(nameof(Helper))]
        public string HelperId  { get; set; }
        public IdentityUser Helper { get; set; }

        [ForeignKey(nameof(Event))]
        public int EventId  { get; set; }
        public Event Event { get; set; }

    }
}