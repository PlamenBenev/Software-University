﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class PurchasesImportXmlDto
    {

        [XmlAttribute("title")]
        [Required]
        public string Title { get; set; }

        [Required]
        public PurchaseType Type { get; set; }

        [Required]
        [RegularExpression("^[A-Z\\d]{4}-[A-Z\\d]{4}-[A-Z\\d]{4}$")]
        public string Key { get; set; }

        [Required]
        [RegularExpression("^(\\d{4}\\s){3}\\d{4}$")]
        public string Card { get; set; }

        [Required]
        public string Date { get; set; }
    }
}
