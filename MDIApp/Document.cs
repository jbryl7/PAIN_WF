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
        private int counter = 0;
        public int getNewIndex()
        {
            counter += 1;
            return counter;
        }
        public event Action<Song> AddSongEvent;
        public event Action<Song> DeleteSongEvent;
        public event Action<Song> UpdateSongEvent;

        public void AddSong( Song song )
        {
            song.Index = getNewIndex();
            songs.Add(song);
            AddSongEvent?.Invoke(song);
        }
        public void UpdateSong(Song song)
        {
            int index = songs.FindIndex(s => s.Index == song.Index);
            songs.RemoveAt(index);
            songs.Insert(index, song);
            UpdateSongEvent?.Invoke(song);
        }
        public void DeleteSong(Song song)
        {
            songs.Remove(song);
            DeleteSongEvent?.Invoke(song);
        }
    }
}
