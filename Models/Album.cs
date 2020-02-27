using System;
using System.Collections.Generic;

namespace rhythm.Models
{
  public class Album
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsExplicit { get; set; } = true;
    public DateTime ReleaseDate { get; set; }
    public int BandId { get; set; }
    public Band Band { get; set; }
    public List<Song> Song { get; set; } = new List<Song>();
  }
}


