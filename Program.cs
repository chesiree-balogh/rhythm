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
            //add list of current bands

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
              //add list of current bands with band id's

              Console.WriteLine($"Which band ID produced this album?");
              newAlbum.BandId = int.Parse(Console.ReadLine().ToLower());

              Console.WriteLine($"Whats the album title?");
              newAlbum.Title = Console.ReadLine().ToLower();

              Console.WriteLine($"Is it explicit, (True) or (False)?");
              newAlbum.IsExplicit = bool.Parse(Console.ReadLine().ToLower());

              Console.WriteLine($"When was it released? YYYY-MM-DD");
              newAlbum.ReleaseDate = DateTime.Parse(Console.ReadLine());

              db.Albums.Add(newAlbum);
              db.SaveChanges();
            }
            else if (whatToProduce == "s")
            {
              //add list of current albums with album id's

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
            //list of current signed bands

            Console.WriteLine($"Which band name would you like to un-sign?");
            var unSign = Console.ReadLine().ToLower();

            var bandToRemove = db.Bands.FirstOrDefault(band => band.BandName == unSign);
            bandToRemove.IsSigned = false;
            db.SaveChanges();
          }


          else if (input == "r")
          {
            //list of current unsigned bands

            Console.WriteLine($"Which band name would you like to re-sign?");
            var reSign = Console.ReadLine().ToLower();

            var bandToReSign = db.Bands.FirstOrDefault(band => band.BandName == reSign);
            bandToReSign.IsSigned = true;
            db.SaveChanges();
          }


          else if (input == "v")
          {
            Console.WriteLine($" What would you like to view?");
            Console.WriteLine($"All albums by (band), all albums by (release) date, ");
            Console.WriteLine($"all (songs) on a album, all (signed) bands, all (unsigned) bands.");
            var viewInput = Console.ReadLine().ToLower();

            //view all albums for a band
            if (viewInput == "band")
            {
              Console.WriteLine($"Which bands albums would you like to see?");
              var whichBand = Console.ReadLine().ToLower();

              var findingBand = db.Bands.FirstOrDefault(w => w.BandName == whichBand);
              var listOfAlbums = db.Albums.Where(w => w.BandId == findingBand.Id);

              Console.WriteLine($"List of albums produced by {findingBand.BandName}: ");
              foreach (var albums in listOfAlbums)
              {
                Console.WriteLine($"{albums.Title}");
              }
            }
            //view all albums, by release date
            else if (viewInput == "release")
            {
              var releaseDate = db.Albums.OrderBy(o => o.ReleaseDate);
              foreach (var release in releaseDate)
              {
                Console.WriteLine($" {release.ReleaseDate}");
              }
            }
            // //view all of a albums song
            else if (viewInput == "songs")
            {
              Console.WriteLine($"Which album would you like to view list of songs from?");
              var whichAlbum = Console.ReadLine().ToLower();

              var findingAlbum = db.Albums.FirstOrDefault(w => w.Title == whichAlbum);
              var songsInAlbum = db.Songs.Where(w => w.AlbumId == findingAlbum.Id);

              Console.WriteLine($"Songs on album {whichAlbum}: ");
              foreach (var songs in songsInAlbum)
              {
                Console.WriteLine($"{songs.Title}");
              }
            }
            //view all bands that are signed
            else if (viewInput == "signed")
            {
              var bandIsSigned = db.Bands.Where(b => b.IsSigned == true);
              foreach (var signed in bandIsSigned)
              {
                Console.WriteLine($" Current signed bands: {signed.BandName}");
              }
            }
            // //view all bands that are not signed
            else if (viewInput == "unsigned")
            {
              var bandNotSigned = db.Bands.Where(b => b.IsSigned == false);
              foreach (var signed in bandNotSigned)
              {
                Console.WriteLine($" Current un-signed bands: {signed.BandName}");
              }
            }
          }


          else if (input == "q")
          {
            isRunning = false;
          }
        }
      }
    }
  }
}