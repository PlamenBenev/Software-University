﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks.Data.Models
{
    public class Despatcher
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }
        public string Position { get; set; }
        public virtual ICollection<Truck> Trucks { get; set; } =
        new HashSet<Truck>();
    }
}