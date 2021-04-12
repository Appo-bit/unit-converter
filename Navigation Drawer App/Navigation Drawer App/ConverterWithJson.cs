using System;
using System.Windows;

namespace UnitConverter
{
	class ConverterWithJson
	{
		public string CategoryOfValue { get; set; }
		public int IndexForVolumeFrom { get; set; }
		public int IndexForVolumeTo { get; set; }

		private JsonParser json;

		public ConverterWithJson(string pathToFile)
		{
			CategoryOfValue = "Weight";
			json = new JsonParser(pathToFile);
		}

		public double ConvertVolume(double volume)
		{
			var inCIVolumeFrom = Double.Parse(json.GetInformation(CategoryOfValue, IndexForVolumeFrom, "inCI"));
			var inCIVolumeTo = Double.Parse(json.GetInformation(CategoryOfValue, IndexForVolumeTo, "inCI"));

			double inCICoefficient = inCIVolumeFrom / inCIVolumeTo;

			return volume * inCICoefficient;
		}
	}
}
