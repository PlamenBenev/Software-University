﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trucks.Data.Models;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Despatcher")]
    public class ExportDespatcherDTO
    {
        public string DespatcherName { get; set; }
        [XmlAttribute("TrucksCount")]
        public int TrucksCount { get; set; }
        [XmlArray("Trucks")]
        public ExportTrucksDTO[] Trucks { get; set; }
    }
}
