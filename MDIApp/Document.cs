using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDIApp
{
    public class Document
    {
        public List<Student> students = new List<Student>();

        public event Action<Student> AddStudentEvent;

        public void AddStudent( Student student )
        {
            students.Add(student);

            //if (AddStudentEvent != null)
            //    AddStudentEvent(student);

            //if ( AddStudentEvent != null)
            //    AddStudentEvent.Invoke(student);

            AddStudentEvent?.Invoke(student);
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
