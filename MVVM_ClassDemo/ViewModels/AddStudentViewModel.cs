using MVVM_ClassDemo.Commands;
using MVVM_ClassDemo.Models;
using MVVM_ClassDemo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_ClassDemo.ViewModels
{
    public class AddStudentViewModel : INotifyPropertyChanged
    {
        public ICommand AddStudentCommand { get; set; }

        private string? firstName; //this is called a BACKING FIELD to store the ACTUAL data. 
        public string? FirstName //this is the "door" through which the UI will interact with the field 
        {
            get => firstName; //Get's the current value of the variable 
            set //updates the value and notifies the UI 
            {
                firstName = value; 
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string? lastName;
        public string? LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string? email;
        public string? Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string? selectedYear;
        public string? SelectedYear
        {
            get => selectedYear;
            set
            {
                selectedYear = value;
                OnPropertyChanged(nameof(SelectedYear));
            }
        }

        private DateTime? birthdate;
        public DateTime? Birthdate
        {
            get => birthdate;
            set
            {
                birthdate = value;
                OnPropertyChanged(nameof(Birthdate));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<string> AvailableYears { get; set; }

        public AddStudentViewModel()
        {
            AddStudentCommand = new RelayCommand(AddStudent, CanAddStudent);

            AvailableYears = new ObservableCollection<string>
            {
                "1st Year", "2nd Year", "3rd Year"
            };

        }

        private bool CanAddStudent(object obj)
        {
            return !string.IsNullOrWhiteSpace(FirstName)
                && !string.IsNullOrWhiteSpace(LastName)
                && !string.IsNullOrWhiteSpace(Email)
                && !string.IsNullOrWhiteSpace(SelectedYear)
                && Birthdate.HasValue;
        }

        private void AddStudent(object obj)
        {
            StudentManager.AddStudent(new Student()
            {
                FirstName = FirstName, 
                LastName = LastName, 
                Email = Email,
                Year = YearStringToInt(SelectedYear),
                Birthdate = Birthdate,
            });

            AddStudent addStudentWin = new AddStudent();
            addStudentWin.Close();
        }
        private int? YearStringToInt(string? year)
        {
            return year switch
            {
                "1st Year" => 1,
                "2nd Year" => 2,
                "3rd Year" => 3,
                _ => null
            };
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            (AddStudentCommand as RelayCommand)?.RaiseCanExecuteChanged(); // This forces the button to refresh
        }
    }
}
