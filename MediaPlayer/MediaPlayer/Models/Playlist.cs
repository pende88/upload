using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace MediaPlayer.Models
{
    public class Playlist
    {

        public int Id { get; set; }
        public string NazivPlayLista { get; set; }

        public ICollection<Pjesma> pjesme { get; set; }

        public Playlist()
        {
            pjesme = new Collection<Pjesma>();
        }


    }
}