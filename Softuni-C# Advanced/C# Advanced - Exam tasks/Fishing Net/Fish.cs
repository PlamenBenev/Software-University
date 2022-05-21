namespace FishingNet
{
    public class Fish
    {
        public string FishType { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        public Fish(string type,double length,double weight)
        {
            FishType = type;
            Length = length;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"There is a {FishType}, {Length} cm. long, and {Weight} gr. in weight.";
        }
    }
}
