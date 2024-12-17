﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Artist.Models
{
    public class ArtistDto
    {
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
        public string ArtMovement { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public string Bio { get; set; }
    }
}
