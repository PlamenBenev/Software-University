using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models
{
    public class Truck
    {
        public int Id { get; set; }
        public string RegistrationNumber  { get; set; }
        public string VinNumber { get; set; }
        public int TankCapacity { get; set; }
        public int CargoCapacity { get; set; }
        public CategoryType CategoryType { get; set; }
        public MakeType MakeType { get; set; }
        public int DespatcherId { get; set; }
        public Despatcher? Despatcher { get; set; }

        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }
            = new HashSet<ClientTruck>();
    }
}
