using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkWithMigration.Entities
{
    [Table("Passangers")]
    public class Client
    {
        //int a = 2;
        // int? b = null;
        //Primary Key namig : Id, id, ID, EntityName + Id
        public int Id { get; set; }
        [Required]//not null
        [MaxLength(100)]//nvarchar(100)
        [Column("FirstName")]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        //Navigation Properties 
        public ICollection<Flight> Flights { get; set; }
    }
}
