﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Watchlist.Data.Models
{
    public class User : IdentityUser
    {
        ICollection<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();
    }
}
