using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("Users")]
    public class UserPurchasesDTO
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlArray]
        public PurchaseDTO[] Purchases { get; set; }
        public decimal TotalSpent { get; set; }
    }
}
