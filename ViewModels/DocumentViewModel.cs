using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WPF_Note.Models;
using WPF_Note.Utility;

namespace WPF_Note.ViewModels
{
	/// <summary>
	/// View Model handling all the data blocks into a coherent document.
	/// </summary>
	public class DocumentViewModel : ObservableObject
	{
		public FileData FileData { get; private set; }

		private object selectedBloc;
		/// <summary>
		/// Currently selected data block.
		/// </summary>
		public object SelectedBloc
		{
			get => selectedBloc;
			set => OnPropertyChanged(ref selectedBloc, value);
		}

		/// <summary>
		/// List of all data blocks making a document.
		/// </summary>
		public ObservableCollection<object> Blocs { get; private set; }

		public ICommand AddTextBlocCommand { get; private set; }
		public ICommand RemoveBlocCommand { get; private set; }

		public DocumentViewModel()
		{
			FileData = new FileData();
			Blocs = new ObservableCollection<object>();
			NewDocument();
			AddTextBlocCommand = new RelayCommand(AddText);
			RemoveBlocCommand = new RelayCommand(RemoveBloc, BlocIsSelected);
		}

		/// <summary>
		/// Function adding a new Text bloc to the document.
		/// </summary>
		private void AddText()
		{
			var bloc = new TextBloc();
			Blocs.Add(bloc);
			SelectedBloc = bloc;
		}

		/// <summary>
		/// Function removing a currently selected block from a document.
		/// </summary>
		private void RemoveBloc()
		{
			Blocs.Remove(SelectedBloc);
			SelectedBloc = Blocs.Count > 0 ? Blocs.Last() : null;
		}

		/// <summary>
		/// Returns true if there is any block selected. Returns false if there is no block selected (no blocks).
		/// </summary>
		private bool BlocIsSelected()
		{
			return SelectedBloc != null;
		}

		/// <summary>
		/// Makes a new document from scratch.
		/// </summary>
		public void NewDocument()
		{
			FileData.FileName = string.Empty;
			FileData.FilePath = string.Empty;
			SelectedBloc = null;
			Blocs.Clear();
		}

		/// <summary>
		/// Creates a document from opened data.
		/// </summary>
		/// <param name="blocs">Collection of data blocks</param>
		/// <param name="fileData">Dialog containing a path to file.</param>
		public void OpenDocument(ObservableCollection<object> blocs, OpenFileDialog fileData)
		{
			SelectedBloc = null;
			Blocs.Clear();
			foreach(object b in blocs)
			{
				Blocs.Add(b);
			}
			FileData.FilePath = fileData.FileName;
			FileData.FileName = fileData.SafeFileName;
		}
	}
}
