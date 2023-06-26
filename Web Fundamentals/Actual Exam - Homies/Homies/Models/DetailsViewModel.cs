namespace Homies.Models
{
    public class DetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Organiser { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int TypeId { get; set; }
        public List<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}