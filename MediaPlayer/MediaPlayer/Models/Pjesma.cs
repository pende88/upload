using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace MediaPlayer.Models
{
    public class Pjesma
    {
        public int Id { get; set; }
        public HttpPostedFileBase file { get; set; }
        public string Lokacija { get; set; }
        public string Naziv { get; set; }
        public string  Zanr { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public int TrackNumber { get; set; }

        public ICollection<Playlist> Playliste { get; set; }
        public Pjesma()
        {
            Playliste = new Collection<Playlist>();
        }

    }
}