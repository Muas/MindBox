using System.Linq;

namespace MindBox
{
	public class CityCard
	{
		public string From { get; set; }
		public string To { get; set; }

		public CityCard()
		{
			
		}

		public CityCard(string cityCard)
		{
			var cities = cityCard.Split('>').Select(x => x.Trim()).ToArray();
			From = cities[0];
			To = cities[1];
		}

		public override string ToString() => $"{From}>{To}";
	}
}