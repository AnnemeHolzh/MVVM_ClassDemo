using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_ClassDemo.Models
{
    public class Student
    {
        public string? FirstName {  get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int? Year { get; set; }
        public DateTime? Birthdate { get; set; }
        public string BirthdateFormatted => Birthdate?.ToString("dd MMM yyyy") ?? "N/A";


    }
}
