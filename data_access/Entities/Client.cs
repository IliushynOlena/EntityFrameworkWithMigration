using data_access.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkWithMigration.Entities
{
    public class Client
    {
        //public int Id { get; set; }//1 2  3  4
        [Key]
        public int CredentialsId { get; set; }//foreign key and primary key
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Rating { get; set; }
        public DateTime? Birthday { get; set; }
        //Navigation Properties 
        public ICollection<Flight> Flights { get; set; }
       
        public Credentials Credentials { get; set; }//null
    }
}
