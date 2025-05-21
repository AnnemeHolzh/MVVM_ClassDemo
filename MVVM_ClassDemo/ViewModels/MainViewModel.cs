using MVVM_ClassDemo.Commands;
using MVVM_ClassDemo.Models;
using MVVM_ClassDemo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_ClassDemo.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Student> Students { get; set; }

        public ICommand ShowWindowCommand { get; set; }

        public MainViewModel()
        {
            Students = StudentManager.GetStudents(); //Gets the collection of students and stores them in the Students collection. 

            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);

        }

        private bool CanShowWindow(object obj)
        {
            return true; //This will determine if the command should continue to evoke. There may be some instances where you would want it to return false. 
        }

        private void ShowWindow(object obj)
        {
            AddStudent addStudentWin = new AddStudent();
            addStudentWin.Show();
        }
    }
}
