using System;

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

            foreach (var c in context.Clients)
            {
                Console.WriteLine($"Client {c.Name}  {c.Email}  {c.Birthday.ToShortDateString()}");
            }
        }
    }


}
