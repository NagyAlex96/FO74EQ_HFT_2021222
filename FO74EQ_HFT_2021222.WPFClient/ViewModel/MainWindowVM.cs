using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FO74EQ_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO74EQ_HFT_2021222.WPFClient.ViewModel
{
    public class MainWindowVM : ObservableRecipient
    {
        public MainWindowVM()
        {
            Students = new RestCollection<Student>("http://localhost:48036/", "Student");

            CreateStudentCommand = new RelayCommand(CreateStudent);
            DeleteStudentCommand = new RelayCommand(DeleteStudent);
            UpdateStudentCommand = new RelayCommand(UpdateStudent);
        }
        public RestCollection<Student> Students { get; set; }

        public IRelayCommand CreateStudentCommand { get; private set; }
        private void CreateStudent()
        {

        }        
        
        public IRelayCommand DeleteStudentCommand { get; private set; }
        private void DeleteStudent()
        {

        }       
        
        public IRelayCommand UpdateStudentCommand { get; private set; }
        private void UpdateStudent()
        {

        }


    }
}
