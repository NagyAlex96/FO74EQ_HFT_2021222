using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FO74EQ_HFT_2021222.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            //enélkül elszáll a program, amennyiben úgy hozunk létre új Studenteket, hogy előtte nem választottunk ki senkit a listából
            selectedStudent = new Student();
            selectedGradeBook = new GradeBook();
            selectedTeacher = new Teacher();

            //fontos a sorrend, amennyiben változik, úgy változtatni kell a frontenden is 
            options = new ObservableCollection<OptionData>
            {
                new OptionData
                {
                    OptionName = "Students",
                    Visibility = Visibility.Visible,
                },

                new OptionData
                {
                    OptionName = "GradeBook",
                    Visibility = Visibility.Hidden,
                },

                new OptionData
                {
                    OptionName = "Teacher",
                    Visibility = Visibility.Hidden,
                }
            };

            if (!IsInDesignMode)
            {
                Students = new RestCollection<Student>("http://localhost:48036/", "Student", "hub");
                CreateStudentCommand = new RelayCommand(CreateStudent);
                UpdateStudentCommand = new RelayCommand(UpdateStudent);
                DeleteStudentCommand = new RelayCommand(DeleteStudent);


                GradeBooks = new RestCollection<GradeBook>("http://localhost:48036/", "GradeBook", "hub");
                CreateGradeBookCommand = new RelayCommand(CreateGradebook);
                UpdateGradeBookCommand = new RelayCommand(UpdateGradeBook);
                DeleteGradeBookCommand = new RelayCommand(DeleteGradeBook);


                Teachers = new RestCollection<Teacher>("http://localhost:48036/", "Teacher", "hub");
                CreateTeacherCommand = new RelayCommand(CreateTeacher);
                UpdateTeacherCommand = new RelayCommand(UpdateTeacher);
                DeleteTeacherCommand = new RelayCommand(DeleteTeacher);
            }
        }

        public ObservableCollection<OptionData> options { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var temp = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(temp, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public RestCollection<Student> Students { get; set; }
        public RestCollection<GradeBook> GradeBooks { get; set; }
        public RestCollection<Teacher> Teachers { get; set; }

        #region Commands

        #region Students
        public IRelayCommand CreateStudentCommand { get; private set; }

        private void CreateStudent()
        {
            bool exist = Students.Where(x => x.NeptunId == selectedStudent.NeptunId).Any();

            if (!exist)
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
            else
            {

                if (MessageBox.Show("Ilyen neptun kóddal már létezik Student.\nIGEN, neptunId max+1 értéket vesz fel.\nNEM: szerkesztés", "", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    Students.Add(new Student()
                    {
                        FirstName = selectedStudent.FirstName,
                        LastName = selectedStudent.LastName,
                        DateOfBirth = selectedStudent.DateOfBirth,
                        Email = selectedStudent.Email,
                        NeptunId = Students.Count() + 1
                    });
                }
            }
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

        #region GradeBook
        public IRelayCommand CreateGradeBookCommand { get; private set; }

        private void CreateGradebook()
        {
            bool exist = GradeBooks.Where(x => x.CourseId == selectedGradeBook.CourseId || x.TeacherId == selectedGradeBook.TeacherId).Any();

            if (!exist)
            {
                GradeBooks.Add(new GradeBook()
                {
                    NeptunId = selectedGradeBook.NeptunId,
                    Grade = selectedGradeBook.Grade,
                    CourseId = selectedGradeBook.CourseId,
                    Rating = selectedGradeBook.Rating,
                    GradeBookId = selectedGradeBook.GradeBookId,
                    TeacherId = selectedGradeBook.TeacherId
                });
            }
            else
            {
                MessageBox.Show("Az adott kurzushoz ön már rögzített jegyet.", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public IRelayCommand UpdateGradeBookCommand { get; private set; }

        private void UpdateGradeBook()
        {
            GradeBooks.Update(selectedGradeBook);
        }

        public IRelayCommand DeleteGradeBookCommand { get; private set; }

        private void DeleteGradeBook()
        {
            if (selectedGradeBook != null)
            {
                GradeBooks.Delete(selectedGradeBook.Grade);
            }
        }

        #endregion

        #region Teacher
        public IRelayCommand CreateTeacherCommand { get; private set; }

        private void CreateTeacher()
        {
            bool exist = Teachers.Where(x => x.TeacherId == selectedTeacher.TeacherId).Any();

            if (!exist)
            {
                Teachers.Add(new Teacher()
                {
                    TeacherId = selectedTeacher.TeacherId,
                    FirstName = selectedTeacher.FirstName,
                    LastName = selectedTeacher.LastName,
                    Salary = selectedTeacher.Salary,
                });
            }
            else
            {
                if (MessageBox.Show("Ilyen TeacherId-val már létezik Teacher.\nIGEN, TeacherID max+1 értéket vesz fel.\nNEM: szerkesztés", "", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    Teachers.Add(new Teacher()
                    {
                        TeacherId = Teachers.Count() + 1,
                        FirstName = selectedTeacher.FirstName,
                        LastName = selectedTeacher.LastName,
                        Salary = selectedTeacher.Salary,
                    });
                }
            }
        }

        public IRelayCommand UpdateTeacherCommand { get; private set; }

        private void UpdateTeacher()
        {
            Teachers.Update(selectedTeacher);
        }

        public IRelayCommand DeleteTeacherCommand { get; private set; }

        private void DeleteTeacher()
        {
            if (selectedGradeBook != null)
            {
                Teachers.Delete(selectedTeacher.TeacherId);
            }
        }
        #endregion

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
                if (value != null)
                {
                    selectedStudent = new Student()
                    {
                        FirstName = value.FirstName,
                        LastName = value.LastName,
                        DateOfBirth = value.DateOfBirth,
                        Email = value.Email,
                        NeptunId = value.NeptunId
                    };
                    OnPropertyChanged();
                }
            }
        }

        private GradeBook selectedGradeBook;
        public GradeBook SelectedGradeBook
        {
            get { return selectedGradeBook; }
            set
            {
                if (value != null)
                {
                    selectedGradeBook = new GradeBook()
                    {
                        NeptunId = value.NeptunId,
                        Grade = value.Grade,
                        CourseId = value.CourseId,
                        GradeBookId = value.GradeBookId,
                        TeacherId = value.TeacherId,
                        Rating = value.Rating,
                    };
                OnPropertyChanged();
                }
            }
        }

        private Teacher selectedTeacher;
        public Teacher SelectedTeacher
        {
            get { return selectedTeacher; }
            set
            {
                if (value != null)
                {
                    selectedTeacher = new Teacher()
                    {
                        FirstName = value.FirstName,
                        LastName = value.LastName,
                        Salary = value.Salary,
                        TeacherId = value.TeacherId,
                    };
                OnPropertyChanged();
                }
            }
        }



        private OptionData selectedOption;
        public OptionData SelectedOption
        {
            get
            {
                if (selectedOption != null)
                {
                    foreach (var item in options)
                    {
                        item.Visibility = (selectedOption.OptionName == item.OptionName ? Visibility.Visible : Visibility.Hidden);
                    }
                }
                return selectedOption;
            }
            set
            {
                selectedOption = value;
                OnPropertyChanged();
            }
        }

        #endregion

    }
}
