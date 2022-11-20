using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FO74EQ_HFT_2021222.WPFClient.ViewModel
{
    public class OptionData : ObservableObject
    {
		private string optionName;

		public string OptionName
        {
			get { return optionName; }
			set { SetProperty(ref optionName, value); }
		}

		private Visibility visibility;

		public Visibility Visibility
		{
			get { return visibility; }
			set { SetProperty(ref visibility, value); }
		}


	}
}
