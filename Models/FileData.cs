using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WPF_Note.Utility;

namespace WPF_Note.Models
{
	/// <summary>
	/// Class holding properties for an entire document.
	/// </summary>
	public class FileData : ObservableObject
	{
		private string fileName;
		/// <summary>
		/// Filename with an extension.
		/// </summary>
		public string FileName
		{
			get => fileName;
			set => OnPropertyChanged(ref fileName, value);
		}

		private string filePath;
		/// <summary>
		/// Full path to file.
		/// </summary>
		public string FilePath
		{
			get => filePath;
			set => OnPropertyChanged(ref filePath, value);
		}
		/// <summary>
		/// Returns true if a file don't have a filepath.
		/// </summary>
		public bool IsEmpty => string.IsNullOrEmpty(FileName) || string.IsNullOrEmpty(FilePath);

	}
}
