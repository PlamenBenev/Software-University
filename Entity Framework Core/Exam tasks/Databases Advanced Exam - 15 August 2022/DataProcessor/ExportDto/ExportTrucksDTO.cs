using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Truck")]
    public class ExportTrucksDTO
    {
        [XmlElement("TruckRegistrationNumber")]
        public string TruckRegistrationNumber { get; set; }
        [XmlElement("Make")]
        public string Make { get; set; }
    }
}
