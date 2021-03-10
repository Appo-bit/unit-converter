using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnitConverter
{
	class JsonParser
	{
		private JObject jsonData;

		public JsonParser(string pathToFile)
		{
			var file = new FileStream(pathToFile, FileMode.OpenOrCreate);
			var reader = new StreamReader(file);
			jsonData = JObject.Parse(reader.ReadToEnd());
		}
		public List<string> GetListOfValues(string CategoryOfValue, string parameter)
		{
			var list = new List<string>();
			for(int value = 0; value < jsonData[CategoryOfValue].Count(); value++)
			{
				list.Add(GetInformation(CategoryOfValue, value, parameter));
			}
			return list;
		}
		public string GetInformation(string CategoryOfValue, int indexOfValue, string parameter)
		{
			return jsonData[CategoryOfValue][indexOfValue][parameter].ToString();
		}
	}
}
