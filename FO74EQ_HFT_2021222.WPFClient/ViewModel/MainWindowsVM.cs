using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FO74EQ_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FO74EQ_HFT_2021222.WPFClient.ViewModel
{
    public class MainWindowsVM : ObservableRecipient
    {
        public MainWindowsVM()
        {
            if (!IsInDesignMode)
            {
                Students = new RestCollection<Student>("http://localhost:48036/", "Student");

                CreateStudentCommand = new RelayCommand(CreateStudent);
                UpdateStudentCommand = new RelayCommand(UpdateStudent);
                DeleteStudentCommand = new RelayCommand(DeleteStudent);
            }
        }

        //TODO: FONTOS
        public static bool IsInDesignMode
        {
            get
            {
                var temp = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(temp, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public RestCollection<Student> Students { get; set; }

        #region Commands
        public IRelayCommand CreateStudentCommand { get; private set; }

        private void CreateStudent()
        {
            Students.Add(new Student()
            {
                FirstName = selectedStudent.FirstName,
                LastName = selectedStudent.LastName,
                DateOfBirth = selectedStudent.DateOfBirth,
                Email = selectedStudent.Email,
                NeptunId = selectedStudent.NeptunId
            });
        }

        public IRelayCommand UpdateStudentCommand { get; private set; }

        private void UpdateStudent()
        {
            Students.Update(selectedStudent);
        }

        public IRelayCommand DeleteStudentCommand { get; private set; }

        private void DeleteStudent()
        {
            if (selectedStudent != null)
            {
                Students.Delete(selectedStudent.NeptunId);
            }
        }
        #endregion


        #region Properties

        /*
         * Setproperty esetén a "weblapon" nem frissül
         * Tehát, kijelölünk egy Studentet majd azt követően ugye betölti az adatait megfelelő helyre. Ezt követően, ha elkezdtük módosítani az adatokat, akkor a listbox-ban egyből változik, még akkor is, ha elkattintunk az adott diákról, miközben a webes felületen nem történik semmi update (csak akkor történik meg, ha rányomunk az update-re)
        */
        private Student selectedStudent;
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set 
            {
                if(value != null)
                {
                    selectedStudent = new Student()
                    {
                        FirstName = value.FirstName,
                        LastName = value.LastName,
                        DateOfBirth = value.DateOfBirth,
                        Email = value.Email,
                        NeptunId = value.NeptunId
                    };
                }
                OnPropertyChanged();
            }
        }
        #endregion

    }
}
