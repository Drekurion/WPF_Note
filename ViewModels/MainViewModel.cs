using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Note.Models;

namespace WPF_Note.ViewModels
{
	public class MainViewModel
	{
		public DocumentViewModel Document { get; set; }
		public FileViewModel File { get; set; }

		public EditViewModel Edit { get; set; }

		public MainViewModel()
		{
			Document = new DocumentViewModel();
			File = new FileViewModel(Document);
			Edit = new EditViewModel();
		}
	}
}
