using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Note.Dialogs;
using WPF_Note.Utility;

namespace WPF_Note.ViewModels
{
	public class HelpViewModel
	{
		public ICommand AboutCommand { get; }

		public HelpViewModel()
		{
			AboutCommand = new RelayCommand(OpenAboutDialog);
		}

		private void OpenAboutDialog()
		{
			var aboutDialog = new AboutDialog();
			aboutDialog.ShowDialog();
		}
	}
}
