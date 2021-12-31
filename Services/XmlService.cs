using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WPF_Note.Models;

namespace WPF_Note.Services
{
	class XmlService : IDataService
	{
		public ICollection<object> Open(string filePath)
		{
			throw new NotImplementedException();
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
