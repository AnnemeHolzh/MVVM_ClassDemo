using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_ClassDemo.Models
{
    public class StudentManager
    {
        /// <summary>
        /// Observable collection of students. 
        /// </summary>
        public static ObservableCollection<Student> Students = new ObservableCollection<Student>();

        public static ObservableCollection<Student> GetStudents()
        {
            return Students;
        }

        public static void AddStudent(Student student)
        {
            Students.Add(student);
        }

    }
}
