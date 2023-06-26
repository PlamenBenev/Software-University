﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Homies.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;


        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime CreatedOn { get; set; }


        public string Organiser { get; set; } = null!;

        public string Type { get; set; } = null!;
    }
}