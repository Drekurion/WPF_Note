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
			if(Blocs.Count > 0)
			{
				SelectedBloc = Blocs.Last();
			}
			else
			{
				SelectedBloc = null;
			}
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
			FileData = new FileData();
			Blocs = new ObservableCollection<object>();
		}
	}
}
