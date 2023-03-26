using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trucks.Data.Models;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportTruckDTO
    {
        [RegularExpression("^[A-Z]{2}\\d{4}[A-Z]{2}$")]

        [Required]
        public string RegistrationNumber { get; set; }
        [Required]
        [StringLength(17)]
        public string VinNumber { get; set; }
        [Range(950,1420)]
        public int TankCapacity { get; set; }
        [Range(5000, 29000)]
        public int CargoCapacity { get; set; }
        [Required]
        public CategoryType Category { get; set; }
        [Required]
        [XmlAttribute("MakeType")]
        public MakeType Make { get; set; }
    }
}
