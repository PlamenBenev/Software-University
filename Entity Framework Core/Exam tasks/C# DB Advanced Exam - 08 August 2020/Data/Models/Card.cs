﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression("^(\\d{4}\\s){3}\\d{4}$")]
        public string Number { get; set; }

        [Required]
        [StringLength(3)]
        public string Cvc { get; set; }

        [Required]
        public CardType Type { get; set; }

        [Required]
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();
    }
}
