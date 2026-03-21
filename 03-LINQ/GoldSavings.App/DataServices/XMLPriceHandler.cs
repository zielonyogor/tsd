using GoldSavings.App.Model;
using System.Xml.Serialization;

namespace GoldSavings.App.DataServices
{
	public class XMLPriceHandler
	{
		public static void SaveToXML(IEnumerable<GoldPrice> goldPrices, string filename)
		{
			string workDir = Directory.GetCurrentDirectory();
			string filePath = Path.Combine(workDir, filename);

			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<GoldPrice>));
			using (StreamWriter writer = new StreamWriter(filePath))
			{
				xmlSerializer.Serialize(writer, goldPrices.ToList());
			}
		}

		public static IEnumerable<GoldPrice> LoadFromXML(string filename)
		{
			return (
				new XmlSerializer(typeof(List<GoldPrice>))
					.Deserialize(
						new StreamReader(
							Path.Combine(Directory.GetCurrentDirectory(), filename)
						)
					) as List<GoldPrice> 
				?? new List<GoldPrice>()
			);
		}
	}
}
