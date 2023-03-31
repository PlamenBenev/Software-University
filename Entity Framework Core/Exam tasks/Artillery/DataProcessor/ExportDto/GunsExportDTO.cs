using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Gun")]
    public class GunsExportDTO
    {
        [XmlAttribute("Manufacturer")]
        public string ManufacturerName { get; set; }
        [XmlAttribute("GunType")]
        public string GunType { get; set; }
        [XmlAttribute("GunWeight")]
        public int GunWeight { get; set; }
        [XmlAttribute("BarrelLength")]
        public string BarrelLength { get; set; }
        [XmlAttribute("Range")]
        public string Range { get; set; }
        [XmlArray]
        public CountriesExportDTO[] Countries { get; set; }
    }
}
