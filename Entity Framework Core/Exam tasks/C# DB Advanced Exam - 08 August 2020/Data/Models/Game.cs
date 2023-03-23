﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaporStore.Data.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int DeveloperId { get; set; }

        [Required]
        public Developer Developer { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();

        public virtual ICollection<GameTag> GameTags  { get; set; } = new HashSet<GameTag>();

    }
}
