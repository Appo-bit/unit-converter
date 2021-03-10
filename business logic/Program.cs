using System;

namespace UnitConverter
{
	class Program
	{
        static void Main(string[] args)
		{
			var pathToFile = "..\\..\\..\\PhysicalValues.JSON";		// Будет в конфиге
			var convert = new ConverterWithJson(pathToFile);
			convert.CategoryOfValue = "Time";
			convert.IndexForVolumeFrom = 1;
			convert.IndexForVolumeTo = 2;

			Console.WriteLine(convert.ConvertVolume(1));
		}
	}
}
