
using EntityFrameworkWithMigration.Entities;
using Microsoft.EntityFrameworkCore;
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

            //context.SaveChanges();

            //foreach (var c in context.Clients)
            //{
            //    Console.WriteLine($"Client {c.Name}  {c.Email}  {c.Birthday}");
            //}

            var filterFlight = context.Flights
                .Include(f=>f.Airplane)//JOIN in SQL
                .Include(f=>f.Clients)//JOIN in SQL
                .Where(f => f.ArrivalCity == "Rivne")
                .OrderBy(f => f.ArrivalTime);
            foreach (var f in filterFlight)
            {
                Console.WriteLine($"Flight :  {f.Number} from: {f.ArrivalCity} to:" +
                    $" {f.DeparturelCity} AirplaneId : {f.AirplaneId} . \n" +
                    $"Model : {f.Airplane?.Model} \n" +
                    $"Count passangesr : {f.Clients.Count}"   );
            }


            var client = context.Clients.Find(2);
            context.Entry(client).Collection(c => c.Flights).Load();//explicit load
            Console.WriteLine($"Client : {client.Id} {client.Name}  {client.Birthday}" +
                $" Flight: {client.Flights.Count}");
            foreach (var f in client.Flights)
            {
                Console.WriteLine($" {f.Number}   {f.DeparturelTime} {f.DeparturelCity}" );
            }
        }
    }


}
