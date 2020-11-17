using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MDIApp
{
    public class Document
    {
        public List<Song> songs = new List<Song>();

        public event Action<Song> AddSongEvent;
        public event Action<Song> DeleteSongEvent;
        public event Action<Song> UpdateSongEvent;

        public void AddSong( Song song )
        {
            songs.Add(song);
            AddSongEvent?.Invoke(song);
        }
        public void UpdateSong(Song song)
        {
            UpdateSongEvent?.Invoke(song);
        }
        public void DeleteSong(Song song)
        {
            songs.Remove(song);
            DeleteSongEvent?.Invoke(song);
        }
    }
}
