using System;
using System.Linq;

namespace MindBox
{
	class Program
	{
		static void Main(string[] args)
		{
			var cityCards = args.Select(x => new CityCard(x));
			var sortedCityCards = new CardsSorter().SortCards(cityCards);
			foreach (var sortedCityCard in sortedCityCards)
			{
				Console.WriteLine(sortedCityCard.ToString());
			}
		}
	}
}
