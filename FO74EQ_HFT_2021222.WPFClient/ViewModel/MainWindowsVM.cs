using FO74EQ_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO74EQ_HFT_2021222.WPFClient.ViewModel
{
    public class MainWindowsVM
    {
        public MainWindowsVM()
        {
            Students = new RestCollection<Student>("http://localhost:48036/","Student");
        }

        public RestCollection<Student> Students { get; set; }

    }
}
