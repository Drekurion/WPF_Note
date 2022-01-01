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
	/// A class for holding text note.
	/// </summary>
	public class TextBloc : ObservableObject
	{
		private string content;
		/// <summary>
		/// Text content.
		/// </summary>
		public string Content
		{
			get => content;
			set => OnPropertyChanged(ref content, value);
		}
		/// <summary>
		/// Font style of displayed content.
		/// </summary>
		private FontStyle style = FontStyles.Normal;
		public FontStyle Style
		{
			get => style;
			set => OnPropertyChanged(ref style, value);
		}

		private FontWeight weight = FontWeights.Normal;
		/// <summary>
		/// Font weight of displayed content.
		/// </summary>
		public FontWeight Weight
		{
			get => weight;
			set => OnPropertyChanged(ref weight, value);
		}

		private FontFamily family = new FontFamily("Consolas");
		/// <summary>
		/// Font family of displayed content.
		/// </summary>
		public FontFamily Family
		{
			get => family;
			set => OnPropertyChanged(ref family, value);
		}

		private int size = 11;
		/// <summary>
		/// Font size of displayed content.
		/// </summary>
		public int Size
		{
			get => size;
			set => OnPropertyChanged(ref size, value);
		}
	}
}
