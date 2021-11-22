﻿using System.Collections.Generic;

namespace BeboerWeb.Domain.Models
{
    public class Lokale
    {
        public Guid Id { get; set; }
        public string Etage { get; set; }
        public double Timepris { get; set; }
        public double Areal { get; set; }
        public bool Koekken { get; set; }
        public bool Badevaerelse { get; set; }

        public List<Booking> Bookinger { get; set; }
        public Bygning Bygning { get; set; }
         
    }
}