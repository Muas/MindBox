using System.Collections.Generic;
using System.Linq;
using MindBox;
using NUnit.Framework;

namespace Tests
{
    public class CardsSorterTests
    {
	    [Test]
	    public void ValidCardsSet_ReturnsSortedCardsSet()
	    {
		    var input = new List<CityCard>()
		    {
			    new CityCard("A>B"),
			    new CityCard("C>D"),
			    new CityCard("B>C")
		    };

		    var output = new CardsSorter().SortCards(input);

		    var expected = new List<CityCard>()
		    {
			    new CityCard("A>B"),
			    new CityCard("B>C"),
			    new CityCard("C>D"),
		    };
		    var isOk = expected.Zip(output, (e, o) => e.From == o.From && e.To == o.To).All(x => x);
			Assert.IsTrue(isOk);
	    }

	    [Test]
	    public void SetIsEmpty_ReturnsEmptySet()
	    {
		    var input = new List<CityCard>();
		    
			var output = new CardsSorter().SortCards(input);

			Assert.IsEmpty(output);
	    }
    }
}
