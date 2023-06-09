﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkWithMigration.Entities
{
    public class Airplane
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Model { get; set; }
        public int MaxPassangers { get; set; }
        //Navigation Properties 
        public ICollection<Flight> Flights { get; set; }
    }
}
