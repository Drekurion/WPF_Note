using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Note.Models;

namespace WPF_Note.Services
{
	public interface IDataService
	{
		ICollection<object> Open(string filePath);
		void Save(ICollection<object> data, string filePath);
	}
}
