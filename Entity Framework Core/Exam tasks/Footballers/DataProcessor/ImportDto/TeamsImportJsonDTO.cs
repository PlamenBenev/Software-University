using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.DataProcessor.ImportDto
{
    public class TeamsImportJsonDTO
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9\\s.-]+$")]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Nationality { get; set; }

        [Required]
        public string Trophies { get; set; }
        public int[] Footballers { get; set; }

    }
}
