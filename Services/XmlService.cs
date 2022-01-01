using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml;
using WPF_Note.Models;

namespace WPF_Note.Services
{
	class XmlService : IDataService
	{
		public ICollection<object> Open(string filePath)
		{
			XmlDocument doc = new XmlDocument
			{
				PreserveWhitespace = true
			};
			doc.Load(filePath);
			XmlNode root = doc.SelectSingleNode("Document");
			ObservableCollection<object> result = new ObservableCollection<object>();
			foreach (XmlNode bloc in root)
			{
				if (bloc.Name == "TextBloc")
				{
					TextBloc textBloc = new TextBloc
					{
						Content = bloc.Attributes["Content"].Value,
						Style = (FontStyle)Enum.Parse(typeof(FontStyle), bloc.Attributes["FontStyle"].Value),
						Weight = (FontWeight)Enum.Parse(typeof(FontWeight), bloc.Attributes["FontWeight"].Value),
						Family = (FontFamily)Enum.Parse(typeof(FontFamily), bloc.Attributes["FontFamily"].Value),
						Size = Convert.ToInt32(bloc.Attributes["FontSize"].Value)
					};
					result.Add(textBloc);
				}
			}
			return result;
		}

		public void Save(ICollection<object> data, string filePath)
		{
			XmlDocument doc = new XmlDocument();
			XmlNode root = doc.CreateNode(XmlNodeType.Element, "Document", null);
			doc.AppendChild(root);
			foreach (object b in data)
			{
				if (b is TextBloc)
				{
					var part = b as TextBloc;
					XmlNode bloc = doc.CreateNode(XmlNodeType.Element, "TextBloc", null);
					root.AppendChild(bloc);

					XmlNode content = doc.CreateNode(XmlNodeType.Element, "Content", null);
					content.InnerText = part.Content;
					bloc.AppendChild(content);

					XmlNode style = doc.CreateNode(XmlNodeType.Element, "FontStyle", null);
					style.InnerText = part.Style.ToString();
					bloc.AppendChild(style);

					XmlNode weight = doc.CreateNode(XmlNodeType.Element, "FontWeight", null);
					weight.InnerText = part.Weight.ToString();
					bloc.AppendChild(weight);

					XmlNode family = doc.CreateNode(XmlNodeType.Element, "FontFamily", null);
					family.InnerText = part.Family.ToString();
					bloc.AppendChild(family);

					XmlNode size = doc.CreateNode(XmlNodeType.Element, "FontSize", null);
					size.InnerText = Convert.ToString(part.Size);
					bloc.AppendChild(size);
				}
			}
			doc.Save(filePath);
		}
	}
}
