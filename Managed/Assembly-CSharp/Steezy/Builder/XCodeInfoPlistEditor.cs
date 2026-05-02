using System;
using System.IO;
using System.Xml;

namespace Steezy.Builder
{
	// Token: 0x020000D7 RID: 215
	public class XCodeInfoPlistEditor
	{
		// Token: 0x06001293 RID: 4755 RVA: 0x0011E850 File Offset: 0x0011CA50
		private static XmlNode FindInfoPlistTopLevelDictNode(XmlDocument doc)
		{
			for (XmlNode xmlNode = doc.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
			{
				if (xmlNode.Name.Equals("plist") && xmlNode.ChildNodes.Count == 1)
				{
					XmlNode firstChild = xmlNode.FirstChild;
					if (firstChild.Name.Equals("dict"))
					{
						return firstChild;
					}
				}
			}
			return null;
		}

		// Token: 0x06001294 RID: 4756 RVA: 0x0011E8AC File Offset: 0x0011CAAC
		private static bool HasKey(XmlNode dict, string keyName)
		{
			for (XmlNode xmlNode = dict.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
			{
				if (xmlNode.Name.Equals("key") && xmlNode.InnerText.Equals(keyName))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001295 RID: 4757 RVA: 0x0011E8F0 File Offset: 0x0011CAF0
		private static XmlElement AddChildElement(XmlDocument doc, XmlNode parent, string elementName, string innerText = null)
		{
			XmlElement xmlElement = doc.CreateElement(elementName);
			if (!string.IsNullOrEmpty(innerText))
			{
				xmlElement.InnerText = innerText;
			}
			parent.AppendChild(xmlElement);
			return xmlElement;
		}

		// Token: 0x06001296 RID: 4758 RVA: 0x0011E920 File Offset: 0x0011CB20
		private static XmlNode GetChildElement(XmlNode node, string elementName, string innerText = null)
		{
			for (XmlNode xmlNode = node.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
			{
				if (xmlNode.Name.Equals(elementName) && ((innerText == null && xmlNode.InnerText == null) || (innerText != null && xmlNode.InnerText.Equals(innerText))))
				{
					return xmlNode;
				}
			}
			return null;
		}

		// Token: 0x06001297 RID: 4759 RVA: 0x0011E970 File Offset: 0x0011CB70
		private static XmlNode UpdateKeyValue(XmlNode node, string key, string elementName, string value)
		{
			XmlNode childElement = XCodeInfoPlistEditor.GetChildElement(node, "key", key);
			if (childElement.NextSibling != null && childElement.NextSibling.Name.Equals(elementName))
			{
				childElement.NextSibling.InnerText = value;
				return childElement;
			}
			return null;
		}

		// Token: 0x06001298 RID: 4760 RVA: 0x0011E9B4 File Offset: 0x0011CBB4
		private static XmlDocument ReadInfoPlist(string path)
		{
			string text = Path.Combine(path, "info.plist");
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(text);
			return xmlDocument;
		}

		// Token: 0x06001299 RID: 4761 RVA: 0x0011E9DC File Offset: 0x0011CBDC
		private static void WriteInfoPlist(string path, XmlDocument doc)
		{
			string text = Path.Combine(path, "info.plist");
			doc.Save(text);
			string text2 = string.Empty;
			using (StreamReader streamReader = new StreamReader(text))
			{
				text2 = streamReader.ReadToEnd();
			}
			int num = text2.IndexOf("<!DOCTYPE plist PUBLIC", StringComparison.Ordinal);
			if (num <= 0)
			{
				return;
			}
			int num2 = text2.IndexOf('>', num);
			if (num2 <= 0)
			{
				return;
			}
			string text3 = text2.Substring(0, num);
			text3 += "<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">";
			text3 += text2.Substring(num2 + 1);
			using (StreamWriter streamWriter = new StreamWriter(text, false))
			{
				streamWriter.Write(text3);
			}
		}

		// Token: 0x0600129A RID: 4762 RVA: 0x0011EAA8 File Offset: 0x0011CCA8
		public static void SetStringValue(string path, string key, string value)
		{
			XmlDocument xmlDocument = XCodeInfoPlistEditor.ReadInfoPlist(path);
			XmlNode xmlNode = XCodeInfoPlistEditor.FindInfoPlistTopLevelDictNode(xmlDocument);
			if (xmlNode == null)
			{
				return;
			}
			if (XCodeInfoPlistEditor.HasKey(xmlNode, key))
			{
				XCodeInfoPlistEditor.UpdateKeyValue(xmlNode, key, "string", value);
			}
			else
			{
				XCodeInfoPlistEditor.AddChildElement(xmlDocument, xmlNode, "key", key);
				XCodeInfoPlistEditor.AddChildElement(xmlDocument, xmlNode, "string", value);
			}
			XCodeInfoPlistEditor.WriteInfoPlist(path, xmlDocument);
		}

		// Token: 0x0600129B RID: 4763 RVA: 0x0011EB04 File Offset: 0x0011CD04
		public static void SetURLScheme(string path, string urlScheme)
		{
			XmlDocument xmlDocument = XCodeInfoPlistEditor.ReadInfoPlist(path);
			XmlNode xmlNode = XCodeInfoPlistEditor.FindInfoPlistTopLevelDictNode(xmlDocument);
			if (xmlNode == null)
			{
				return;
			}
			XmlNode xmlNode2 = null;
			if (XCodeInfoPlistEditor.HasKey(xmlNode, "CFBundleURLTypes"))
			{
				xmlNode2 = XCodeInfoPlistEditor.GetChildElement(xmlNode, "key", "CFBundleURLTypes").NextSibling;
			}
			else
			{
				XCodeInfoPlistEditor.AddChildElement(xmlDocument, xmlNode, "key", "CFBundleURLTypes");
				xmlNode2 = XCodeInfoPlistEditor.AddChildElement(xmlDocument, xmlNode, "array", null);
			}
			foreach (object obj in xmlNode2.ChildNodes)
			{
				XmlNode xmlNode3 = (XmlNode)obj;
				if (xmlNode3.Name.Equals("dict") && xmlNode3.HasChildNodes)
				{
					xmlNode2.RemoveChild(xmlNode3);
					break;
				}
			}
			string innerText = XCodeInfoPlistEditor.GetChildElement(xmlNode, "key", "CFBundleIdentifier").NextSibling.InnerText;
			XmlNode xmlNode4 = XCodeInfoPlistEditor.AddChildElement(xmlDocument, xmlNode2, "dict", null);
			XCodeInfoPlistEditor.AddChildElement(xmlDocument, xmlNode4, "key", "CFBundleURLName");
			XCodeInfoPlistEditor.AddChildElement(xmlDocument, xmlNode4, "string", innerText);
			XCodeInfoPlistEditor.AddChildElement(xmlDocument, xmlNode4, "key", "CFBundleURLSchemes");
			XmlNode xmlNode5 = XCodeInfoPlistEditor.AddChildElement(xmlDocument, xmlNode4, "array", null);
			XCodeInfoPlistEditor.AddChildElement(xmlDocument, xmlNode5, "string", urlScheme);
			XCodeInfoPlistEditor.WriteInfoPlist(path, xmlDocument);
		}
	}
}
