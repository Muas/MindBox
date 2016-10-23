using System;
using System.Collections.Generic;
using System.Linq;

namespace MindBox
{
	public class CardsSorter
	{
		public IEnumerable<CityCard> SortCards(IEnumerable<CityCard> cityCards)
		{
			if (cityCards == null) throw new ArgumentNullException(nameof(cityCards));

			var map = cityCards.ToDictionary(x => x.From, x => x.To);
			if (!map.Any()) yield break;

			var departureCity = map.Keys.Except(map.Values).FirstOrDefault();
			if(departureCity == null) throw new InvalidOperationException("Sequence containce a loop");

			string arrivalCity;
			while (map.TryGetValue(departureCity, out arrivalCity))
			{
				yield return new CityCard() { From = departureCity , To = arrivalCity};
				departureCity = arrivalCity;
			}
		}
	}
}