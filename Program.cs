using System;
using rhythm.Models;
using System.Linq;

namespace rhythm
{
  class Program
  {
    static void Main(string[] args)
    {
      static void PopulateDatabase()
      {
        // check if there are any cohorts,
        var db = new DatabaseContext();
        if (!db.Bands.Any())
        {
          // if none then add a few
          db.Bands.Add(new Band
          {
            BandName = "Damien Rice",
            CountryOfOrigin = "Ireland",
            NumberOfMembers = "1",
            Website = "Damien.Rice@gmail.com",
            Style = "Indie",
            IsSigned = true,
            PersonOfContact = "Damien Rice",
            ContactPhoneNumber = "813-422-2244",
          });
          db.Bands.Add(new Band
          {
            BandName = "A Day To Remember",
            CountryOfOrigin = "America",
            NumberOfMembers = "4",
            Website = "ADTR@aol.com",
            Style = "Rock",
            IsSigned = true,
            PersonOfContact = "Joe Schmoe",
            ContactPhoneNumber = "727-483-3848",
          });
          db.SaveChanges();
        }
      }



      {
        Console.WriteLine("Welcome to Rhythm!");
        var newBand = new Band();
        PopulateDatabase();

        var isRunning = true;
        while (isRunning)
        {
          var db = new DatabaseContext();


          Console.WriteLine($"Which would you like to do?");
          Console.WriteLine($"Add a (B)and, Add a (A)lbum, (L)et a band go, (R)esign a band, (V)iew, or (Q)uit");
          var input = Console.ReadLine().ToLower();

          if (input == "b")
          {
            Console.WriteLine($"Whats the bands name?");
            newBand.BandName = Console.ReadLine().ToLower();

            Console.WriteLine($"What country are they from?");
            newBand.BandName = Console.ReadLine().ToLower();

            Console.WriteLine($"How many band members are there?");
            newBand.BandName = Console.ReadLine().ToLower();

            Console.WriteLine($"Whats their website?");
            newBand.BandName = Console.ReadLine().ToLower();

            Console.WriteLine($"Whats their music style?");
            newBand.BandName = Console.ReadLine().ToLower();

            Console.WriteLine($"Are they signed?");
            newBand.BandName = Console.ReadLine().ToLower();

            Console.WriteLine($"Person of contact?");
            newBand.BandName = Console.ReadLine().ToLower();

            Console.WriteLine($"Contact phone number?");
            newBand.BandName = Console.ReadLine().ToLower();
            db.SaveChanges();
          }


          // else if (input == "a")
          // {

          // }

          // else if (input == "l")
          // {

          // }

          // else if (input == "r")
          // {

          // }

          // else if (input == "v")
          // {

          // }
          // else if (input == "q")
          // {
          //   isRunning = false;
          // }
        }
      }
    }
  }
}