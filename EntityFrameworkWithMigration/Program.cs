
using EntityFrameworkWithMigration.Entities;
using System;
using System.Linq;

namespace EntityFrameworkWithMigration
{
    internal class Program
    {
        static void Main(string[] args)
        {

            AirplaneDbContext context = new AirplaneDbContext();

            context.Clients.Add(new Client
            {
                Name = "Volodia",
                Birthday = new DateTime(2006, 12, 1),
                Email = "volodia@gmail.com"
            });

            context.SaveChanges();

            //foreach (var c in context.Clients)
            //{
            //    Console.WriteLine($"Client {c.Name}  {c.Email}  {c.Birthday}");
            //}

            var filterFlight = context.Flights.Where(f => f.ArrivalCity == "Rivne").OrderBy(f => f.ArrivalTime);
            foreach (var f in filterFlight)
            {
                Console.WriteLine($"Flight :  {f.Number} from: {f.ArrivalCity} to: {f.DeparturelCity}");
            }
        }
    }


}
