using EntityFrameworkWithMigration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Credentials
    {
        public int Id { get; set; }//1  2  3 
        public string Login { get; set; }
        public string Password { get; set; }
        public int? ClientId { get; set; }//null
        public Client  Client { get; set; }
    }
}
