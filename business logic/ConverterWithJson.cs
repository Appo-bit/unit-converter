using System;

namespace UnitConverter
{
	class ConverterWithJson
	{
		public string CategoryOfValue { get; set; }
		public int IndexForVolumeFrom { get; set; }
		public int IndexForVolumeTo { get; set; }
		
		private bool flag;  // true -> IndexForVolumeFrom > IndexForVolumeTo 

		private JsonParser json;

		public ConverterWithJson(string pathToFile)
		{
			CategoryOfValue = "Weight";
			IndexForVolumeTo = 0;
			IndexForVolumeFrom = 1;
			json = new JsonParser(pathToFile);
			flag = true;
		}

		public void inCIFromMore()
		{
			var inCIVolumeFrom = Double.Parse(json.GetInformation(CategoryOfValue, IndexForVolumeFrom, "inCI"));
			var inCIVolumeTo = Double.Parse(json.GetInformation(CategoryOfValue, IndexForVolumeTo, "inCI"));

			if (inCIVolumeFrom > inCIVolumeTo)
				flag = true;
			else
				flag = false;
		}

		public double ConvertVolume(double volume)
		{
			var inCIVolumeFrom = Double.Parse(json.GetInformation(CategoryOfValue, IndexForVolumeFrom, "inCI"));
			var inCIVolumeTo = Double.Parse(json.GetInformation(CategoryOfValue, IndexForVolumeTo, "inCI"));

			double inCICoefficient = inCIVolumeFrom / inCIVolumeTo;

			if (flag)
				return volume * inCICoefficient;

			return volume / inCICoefficient;
		}
	}
}
