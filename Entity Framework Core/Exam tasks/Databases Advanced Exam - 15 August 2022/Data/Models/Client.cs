using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks.Data.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string Type { get; set; }
        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }
        = new HashSet<ClientTruck>();
    }
}
