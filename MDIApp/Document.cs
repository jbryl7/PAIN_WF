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
        public event Action<Song> DeleteSongEvent;
        public event Action<Song> UpdateSongEvent;

        public void AddSong( Song student )
        {
            students.Add(student);
            AddSongEvent?.Invoke(student);
        }
        public void UpdateSong(Song student)
        {
            students.Insert(students.FindIndex(s => s.Index == student.Index), student);
            UpdateSongEvent?.Invoke(student);
        }
        public void DeleteSong(Song student)
        {
            students.Remove(student);
            DeleteSongEvent?.Invoke(student);
        }
    }
}
