using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Note.Utility;

namespace WPF_Note.ViewModels
{
	/// <summary>
	/// View model handling undo, redo, copy & paste operations.
	/// </summary>
	public class EditViewModel
	{
		public ICommand UndoCommand { get; private set; }
		public ICommand RedoCommand { get; private set; }
		public ICommand CutCommand { get; private set; }
		public ICommand CopyCommand { get; private set; }
		public ICommand PasteCommand { get; private set; }

		public EditViewModel()
		{
			UndoCommand = ApplicationCommands.Undo;
			RedoCommand = ApplicationCommands.Redo;
			CutCommand = ApplicationCommands.Cut;
			CopyCommand = ApplicationCommands.Copy;
			PasteCommand = ApplicationCommands.Paste;
		}
	}
}
