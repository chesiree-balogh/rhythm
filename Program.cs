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
        PopulateDatabase();

        var newBand = new Band();
        var newAlbum = new Album();
        var newSong = new Song();

        var isRunning = true;
        while (isRunning)
        {
          var db = new DatabaseContext();


          Console.WriteLine($"Which would you like to do?");
          Console.WriteLine($"Add a (B)and, (P)roduce, (L)et a band go, (R)esign a band, (V)iew, or (Q)uit");
          var input = Console.ReadLine().ToLower();

          if (input == "b")
          {
            Console.WriteLine($"Whats the bands name?");
            newBand.BandName = Console.ReadLine().ToLower();

            Console.WriteLine($"What country are they from?");
            newBand.CountryOfOrigin = Console.ReadLine().ToLower();

            Console.WriteLine($"How many band members are there?");
            newBand.NumberOfMembers = Console.ReadLine().ToLower();

            Console.WriteLine($"Whats their website?");
            newBand.Website = Console.ReadLine().ToLower();

            Console.WriteLine($"Whats their music style?");
            newBand.Style = Console.ReadLine().ToLower();

            Console.WriteLine($"Are they signed, (True) or (False)?");
            newBand.IsSigned = bool.Parse(Console.ReadLine().ToLower());

            Console.WriteLine($"Person of contact?");
            newBand.PersonOfContact = Console.ReadLine().ToLower();

            Console.WriteLine($"Contact phone number?");
            newBand.ContactPhoneNumber = Console.ReadLine().ToLower();
            db.Bands.Add(newBand);
            db.SaveChanges();
          }


          else if (input == "p")
          {
            Console.WriteLine($"What would you like to produce: A (A)lbum or a (S)ong?");
            var whatToProduce = Console.ReadLine().ToLower();
            if (whatToProduce == "a")
            {
              Console.WriteLine($"Which band ID produced this album?");
              newAlbum.BandId = int.Parse(Console.ReadLine().ToLower());

              Console.WriteLine($"Whats the album title?");
              newAlbum.Title = Console.ReadLine().ToLower();

              Console.WriteLine($"Is it explicit, (True) or (False)?");
              newAlbum.IsExplicit = bool.Parse(Console.ReadLine().ToLower());

              Console.WriteLine($"When was it released?");
              newAlbum.ReleaseDate = DateTime.Parse(Console.ReadLine());

              db.Albums.Add(newAlbum);
              db.SaveChanges();
            }
            else if (whatToProduce == "s")
            {
              Console.WriteLine($"Which album ID does this song belong to?");
              newSong.AlbumId = int.Parse(Console.ReadLine().ToLower());

              Console.WriteLine($"What is the song title?");
              newSong.Title = Console.ReadLine().ToLower();

              Console.WriteLine($"What are some lyrics?");
              newSong.Lyrics = Console.ReadLine().ToLower();

              Console.WriteLine($"How long is the song?");
              newSong.Length = Console.ReadLine().ToLower();

              Console.WriteLine($"What is the genre?");
              newSong.Genre = Console.ReadLine().ToLower();

              db.Songs.Add(newSong);
              db.SaveChanges();
            }
          }

          else if (input == "l")
          {
            Console.WriteLine($"Which band name would you like to un-sign?");
            var unSign = Console.ReadLine().ToLower();

            var bandToRemove = db.Bands.FirstOrDefault(band => band.BandName == unSign);
            bandToRemove.IsSigned = false;
            db.SaveChanges();
          }


          else if (input == "r")
          {
            Console.WriteLine($"Which band name would you like to re-sign?");
            var reSign = Console.ReadLine().ToLower();

            var bandToReSign = db.Bands.FirstOrDefault(band => band.BandName == reSign);
            bandToReSign.IsSigned = true;
            db.SaveChanges();
          }

          // else if (input == "v")
          // {

          // }
          else if (input == "q")
          {
            isRunning = false;
          }
        }
      }
    }
  }
}