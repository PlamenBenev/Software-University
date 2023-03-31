
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells.ToArray()
                .Where(s => s.ShellWeight > shellWeight)
                .Select(s => new
                {
                    ShellWeight = s.ShellWeight.ToString("f1"),
                    s.Caliber,
                    Guns = s.Guns
                        .Where(g => g.GunType.ToString() == "AntiAircraftGun")
                        .Select(g => new
                        {
                            GunType = g.GunType.ToString(),
                            g.GunWeight,
                            g.BarrelLength,
                            Range = g.Range > 3000 ? "Long-range" : "Regular range"
                        })
                        .OrderByDescending(g => g.GunWeight)
                        .ToArray()
                })
                .OrderBy(s =>double.Parse(s.ShellWeight))
                .ToArray();

            return JsonConvert.SerializeObject(shells,Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var guns = context.Guns
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .ToArray()
                .Select(g => new GunsExportDTO
                {
                    ManufacturerName = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    GunWeight = g.GunWeight,
                    BarrelLength = g.BarrelLength.ToString(),
                    Range = g.Range.ToString(),
                    Countries = g.CountriesGuns
                        .Where(c => c.Country.ArmySize > 4500000)
                        .Select(c => new CountriesExportDTO
                        {
                            CountryName = c.Country.CountryName,
                            ArmySize = c.Country.ArmySize.ToString(),
                        })
                        .OrderBy(c => int.Parse(c.ArmySize))
                        .ToArray()
                })
                .OrderBy(g => double.Parse(g.BarrelLength))
                .ToArray();


            var serializer = new XmlSerializer(typeof(GunsExportDTO[]),
                  new XmlRootAttribute("Guns"));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var strWriter = new StringWriter();
            serializer.Serialize(strWriter, guns, ns);
            return strWriter.ToString();

        }
    }
}
