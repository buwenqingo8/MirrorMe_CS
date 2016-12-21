using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace CoreHandle
{
	public class JsonHelper
	{

		public static string JsonSerializer<T>(T t)
		{
			DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
			MemoryStream memoryStream = new MemoryStream();
			dataContractJsonSerializer.WriteObject(memoryStream, t);
			string @string = Encoding.UTF8.GetString(memoryStream.ToArray());
			memoryStream.Close();
			return @string;
		}
		public static T JsonDeserialize<T>(string jsonString)
		{
			DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
			MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            
			return (T)((object)dataContractJsonSerializer.ReadObject(stream));
		}
	}
}
