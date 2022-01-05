using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WPF_Note.Utility;

namespace WPF_Note.Models
{
	/// <summary>
	/// A class for holding an image.
	/// </summary>
	public class ImageBloc : ObservableObject
	{
		private BitmapImage content;
		public BitmapImage Content
		{
			get => content;
			set => OnPropertyChanged(ref content, value);
		}

		public ImageBloc(BitmapImage image)
		{
			Content = image;
		}
	}
}
