namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Text;
    using System.Xml.Serialization;
    using Castle.Core.Internal;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ExportDto;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            var sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportDespatcherDTO[]), new XmlRootAttribute("Despatchers"));

            using StringReader stringReader = new StringReader(xmlString);
            ImportDespatcherDTO[] despatcherDtos = 
                (ImportDespatcherDTO[])xmlSerializer.Deserialize(stringReader);



            foreach (var despatcherJson in despatcherDtos)
            {
                if (!IsValid(despatcherJson) || string.IsNullOrEmpty(despatcherJson.Position))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var data = new Despatcher
                {
                    Name = despatcherJson.Name,
                    Position = despatcherJson.Position,
                };

                foreach (var truck in despatcherJson.Trucks)
                {
                    if (!IsValid(truck))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var despTruck = new Truck
                    {
                        RegistrationNumber = truck.RegistrationNumber,
                        VinNumber = truck.VinNumber,
                        TankCapacity = truck.TankCapacity,
                        CargoCapacity = truck.CargoCapacity,
                        CategoryType = (CategoryType)truck.CategoryType,
                        MakeType = (MakeType)truck.MakeType,
                    };
                    data.Trucks.Add(despTruck);
                }
                context.Despatchers.Add(data );
                context.SaveChanges();
                sb.AppendLine($"Successfully imported despatcher - {data.Name} with {data.Trucks.Count} trucks.");
            }

            return sb.ToString();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            var sb = new StringBuilder();
            ClientsImportDTO[] serializer = JsonConvert
                .DeserializeObject<ClientsImportDTO[]>(jsonString);

            foreach (var item in serializer)
            {
                if (!IsValid(item) || item.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var client = new Client()
                {
                    Name = item.Name,
                    Nationality = item.Nationality,
                    Type = item.Type,
                };

                foreach (var truck in item.Trucks.Distinct())
                {
                    var t = context.Trucks.Find(truck);
                    if (!IsValid(truck) || t == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    client.ClientsTrucks.Add(new ClientTruck() { Truck = t });
                }

                context.Clients.Add(client);
                context.SaveChanges();
                sb.AppendLine($"Successfully imported client - {client.Name} with {client.ClientsTrucks.Count} trucks.");
            }

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}