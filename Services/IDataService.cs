using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WPF_Note.Services
{
	public interface IDataService
	{
		ObservableCollection<object> Open(string filePath);
		void Save(ObservableCollection<object> data, string filePath);
	}
}
