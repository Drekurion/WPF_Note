using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;
using WPF_Note.Services;
using WPF_Note.Utility;

namespace WPF_Note.ViewModels
{
	/// <summary>
	/// View model handling file related operations.
	/// </summary>
	public class FileViewModel
	{
		/// <summary>
		/// View model containing all content blocs.
		/// </summary>
		private DocumentViewModel Document { get; set; }

		/// <summary>
		/// Service handling opening and saving a file.
		/// </summary>
		private IDataService dataService = new XmlService();

		public ICommand NewCommand { get; }
		public ICommand OpenCommand { get; }
		public ICommand SaveCommand { get; }
		public ICommand SaveAsCommand { get; }
		public ICommand ExitCommand { get; }

		/// <summary>
		/// View model handling file operations such as open or save.
		/// </summary>
		/// <param name="document">View model containing all content blocs.</param>
		public FileViewModel(DocumentViewModel document)
		{
			Document = document;
			NewCommand = new RelayCommand(NewFile);
			OpenCommand = new RelayCommand(OpenFile);
			SaveCommand = new RelayCommand(SaveFile);
			SaveAsCommand = new RelayCommand(SaveFileAs);
			ExitCommand = new RelayCommand(Exit);
		}

		private void NewFile()
		{
			Document.NewDocument();
		}

		private void OpenFile()
		{
			var openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == true)
			{
				var blocs = dataService.Open(openFileDialog.FileName);
				Document.OpenDocument(blocs, openFileDialog);
			}
		}

		private void SaveFile()
		{
			if(!Document.FileData.IsEmpty)
			{
				dataService.Save(Document.Blocs, Document.FileData.FilePath);
			}
			else
			{
				SaveFileAs();
			}
		}

		private void SaveFileAs()
		{
			var saveFileDialog = new SaveFileDialog
			{
				Filter = "XML File (*.xml)|*.xml"
			};
			if (saveFileDialog.ShowDialog() == true)
			{
				Document.FileData.FilePath = saveFileDialog.FileName;
				Document.FileData.FileName = saveFileDialog.SafeFileName;
				dataService.Save(Document.Blocs, saveFileDialog.FileName);
			}
		}

		private void Exit()
		{
			Application.Current.Shutdown();
		}
	}
}
