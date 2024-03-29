﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Note.Dialogs;
using WPF_Note.Utility;

namespace WPF_Note.ViewModels
{
	public class FormatViewModel
	{
		private DocumentViewModel Document { get; set; }

		public ICommand FormatCommand { get; }

		public FormatViewModel(DocumentViewModel document)
		{
			Document = document;
			FormatCommand = new RelayCommand(OpenFormatDialog, Document.BlocIsSelected);
		}

		private void OpenFormatDialog()
		{
			var fontDialog = new FontDialog();
			fontDialog.DataContext = Document.SelectedBloc;
			fontDialog.ShowDialog();
		}
	}
}
