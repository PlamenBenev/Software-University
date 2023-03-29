namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportXMLCoachesDTO[]),
                new XmlRootAttribute("Coaches"));

            using StringReader stringReader = new StringReader(xmlString);

            ImportXMLCoachesDTO[] coaches = (ImportXMLCoachesDTO[])xmlSerializer.Deserialize(stringReader);

            foreach (var c in coaches)
            {
                if (!IsValid(c) || string.IsNullOrEmpty(c.Nationality))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var coach = new Coach
                {
                    Name = c.Name,
                    Nationality = c.Nationality,
                    Footballers = new List<Footballer>()
                };

                foreach (var fb in c.Footballers)
                {
                    var validedStartDate = DateTime
                    .TryParseExact(fb.ContractStartDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var contractStartDate);

                    var validedEndDate = DateTime
                    .TryParseExact(fb.ContractEndDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var contractEndDate);
                    if (!IsValid(fb) || !IsValid(fb.Name) 
                        || contractStartDate > contractEndDate
                        || !IsValid(fb.ContractStartDate) || !IsValid(fb.ContractStartDate))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var footballer = new Footballer
                    {
                        Name = fb.Name,
                        ContractStartDate = contractStartDate,
                        ContractEndDate = contractEndDate,
                        BestSkillType = (BestSkillType)fb.BestSkillType,
                        PositionType = (PositionType)fb.PositionType,
                    };

                coach.Footballers.Add(footballer);
                }
                context.Coaches.Add(coach);
                sb.AppendLine($"Successfully imported coach - {coach.Name} with {coach.Footballers.Count} footballers.");
            }
            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
           var sb = new StringBuilder();

            var serializer = JsonConvert.DeserializeObject<TeamsImportJsonDTO[]>(jsonString);

            foreach (var t in serializer)
            {
                if (!IsValid(t) || t.Nationality == null || int.Parse(t.Trophies) == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var team = new Team()
                {
                    Name = t.Name,
                    Nationality = t.Nationality,
                    Trophies = int.Parse(t.Trophies),
                };
                foreach (var f in t.Footballers.Distinct())
                {
                    var footballer = context.Footballers.FirstOrDefault(x => x.Id == f);
                    if (!IsValid(f) || footballer == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    team.TeamsFootballers.Add(new TeamFootballer()
                    {
                        FootballerId = footballer.Id, 
                        Footballer = footballer
                    });
                }
                context.Teams.Add(team);
            context.SaveChanges();
                sb.AppendLine($"Successfully imported team - {team.Name} with {team.TeamsFootballers.Count} footballers.");
            }
            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
