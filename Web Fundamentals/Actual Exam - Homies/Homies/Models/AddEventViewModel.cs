namespace Homies.Models
{
    public class AddEventViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int TypeId { get; set; }
        public IEnumerable<Data.DataModels.Type> Types { get; set; } = new List<Data.DataModels.Type>();

    }
}
