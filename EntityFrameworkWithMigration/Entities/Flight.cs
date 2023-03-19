using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkWithMigration.Entities
{
    public class Flight
    {
        [Key]
        public int Number { get; set; }
        [Required, MaxLength(100)]
        public string ArrivalCity { get; set; }
        [Required, MaxLength(100)]
        public string DeparturelCity { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DeparturelTime { get; set; }
        //Foreign key : RelatedEntityName + RelatedEntityPrimaryKeyName
        public int AirplaneId { get; set; }
        //Navigation Properties 
        public Airplane Airplane { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
}
