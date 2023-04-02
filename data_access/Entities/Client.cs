using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkWithMigration.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Rating { get; set; }
        public DateTime? Birthday { get; set; }
        //Navigation Properties 
        public ICollection<Flight> Flights { get; set; }
    }
}
