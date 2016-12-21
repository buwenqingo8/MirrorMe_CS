
using System;
using System.IO;
using System.Xml.Serialization;
namespace Util
{
	public static class XmlSerializer
	{
		public static void SaveToXml(string filePath, object sourceObj)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(filePath) && sourceObj != null)
				{
					Type type = sourceObj.GetType();
					using (StreamWriter streamWriter = new StreamWriter(filePath))
					{
						System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(type);
						xmlSerializer.Serialize(streamWriter, sourceObj);
					}
				}
			}
			catch (Exception ex)
			{
				
			}
		}
		public static object LoadFromXml(string filePath, Type type)
		{
			object result = null;
			try
			{
				if (File.Exists(filePath))
				{
					using (StreamReader streamReader = new StreamReader(filePath))
					{
						System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(type);
						result = xmlSerializer.Deserialize(streamReader);
					}
				}
			}
			catch (Exception ex)
			{
				
			}
			return result;
		}
	}
}
