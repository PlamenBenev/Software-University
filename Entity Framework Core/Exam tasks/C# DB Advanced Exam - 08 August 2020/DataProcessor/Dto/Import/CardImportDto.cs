using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class CardImportDto
    {
        [Required]
        [RegularExpression("^(\\d{4}\\s){3}\\d{4}$")]
        public string Number { get; set; }

        [Required]
        [StringLength(3)]
        public string Cvc { get; set; }

        [Required]
        public CardType? Type { get; set; }
    }
}
