using System.ComponentModel.DataAnnotations;

namespace Homies.Data.DataModels
{
    public class Type
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; } = null!;
        public ICollection<Event> Events { get; set; } = new List<Event>();

    }
}
