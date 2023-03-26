using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks.Data.Models
{
    public class Despatcher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public virtual ICollection<Truck> Trucks { get; set; } =
        new HashSet<Truck>();
    }
}
