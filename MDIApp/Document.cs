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

        public event Action<Song> AddStudentEvent;

        public void AddStudent( Song student )
        {
            students.Add(student);

            //if (AddStudentEvent != null)
            //    AddStudentEvent(student);

            //if ( AddStudentEvent != null)
            //    AddStudentEvent.Invoke(student);

            AddStudentEvent?.Invoke(student);
        }

        public void UpdateStudent(Song student)
        {
            throw new NotImplementedException();
        }
    }
}
