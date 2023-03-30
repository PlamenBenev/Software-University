namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCountriesXMLDTO[]),
                new XmlRootAttribute("Countries"));

            using StringReader stringReader = new StringReader(xmlString);

            ImportCountriesXMLDTO[] countries = (ImportCountriesXMLDTO[])xmlSerializer.Deserialize(stringReader);

            foreach (var item in countries)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var country = new Country
                {
                    CountryName = item.CountryName,
                    ArmySize = item.ArmySize
                };

                context.Countries.Add(country);
                sb.AppendLine($"Successfully import {country.CountryName} with {country.ArmySize} army personnel.");
            }
            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportManufacturerXmlDTO[]),
                new XmlRootAttribute("Manufacturers"));

            using StringReader stringReader = new StringReader(xmlString);

            ImportManufacturerXmlDTO[] manufacturers = 
                (ImportManufacturerXmlDTO[])xmlSerializer.Deserialize(stringReader);

            foreach (var item in manufacturers)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var manufacturer = new Manufacturer
                {
                    ManufacturerName = item.ManufacturerName,
                    Founded = item.Founded
                };

                int index = manufacturer.Founded.IndexOf(", ", manufacturer.Founded.IndexOf(", ") + 1);
                string result = manufacturer.Founded.Substring(index + 2);

                context.Manufacturers.Add(manufacturer);
                sb.AppendLine($"Successfully import manufacturer {manufacturer.ManufacturerName} founded in {result}.");
            }
            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportShellsXmlDTO[]),
                new XmlRootAttribute("Shells"));

            using StringReader stringReader = new StringReader(xmlString);

            ImportShellsXmlDTO[] shells = (ImportShellsXmlDTO[])xmlSerializer.Deserialize(stringReader);

            foreach (var item in shells)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var shell = new Shell
                {
                    ShellWeight = item.ShellWeight,
                    Caliber = item.Caliber
                };


                context.Shells.Add(shell);
                sb.AppendLine($"Successfully import shell caliber #{shell.Caliber} weight {shell.ShellWeight} kg.");
            }
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var serializer = JsonConvert.DeserializeObject<ImportGunsJsonDTO[]>(jsonString);

            foreach (var item in serializer)
            {
                bool isValidNumberBuild = int.TryParse(item.NumberBuild, out int numberBuild);
                bool isValidGuntype = Enum.TryParse<GunType>(item.GunType, out GunType gunType);
                if (!IsValid(item) || !isValidGuntype)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var gun = new Gun
                {
                    ManufacturerId = item.ManufacturerId,
                    GunWeight = item.GunWeight,
                    BarrelLength = item.BarrelLength,
                    NumberBuild = numberBuild,
                    Range = item.Range,
                    GunType = gunType,
                    ShellId = item.ShellId,
                    CountriesGuns = item.Countries.Select(c => new CountryGun
                    {
                        CountryId = c.Id
                    })
                    .ToArray()
                };
                context.Guns.Add(gun);
                sb.AppendLine($"Successfully import gun {gun.GunType} with a total weight of {gun.GunWeight} kg. and barrel length of {gun.BarrelLength} m.");
            }
            context.SaveChanges();
           return sb.ToString();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}