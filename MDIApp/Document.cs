using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MDIApp
{
    public class Document
    {
        public List<Song> students = new List<Song>();

        public event Action<Song> AddSongEvent;

        public void AddSong( Song student )
        {
            students.Add(student);

            //if (AddSongEvent != null)
            //    AddSongEvent(student);

            //if ( AddSongEvent != null)
            //    AddSongEvent.Invoke(student);

            AddSongEvent?.Invoke(student);
        }

        public void UpdateSong(Song student)
        {
            throw new NotImplementedException();
        }
    }
}
