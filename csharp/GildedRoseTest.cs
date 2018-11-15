using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [TestCase(0, "Sulfuras, Hand of Ragnaros", TestName = " of Sulfuras is unchanged")]
        [TestCase(-1, "The One Ring", TestName = " of everything else decreases by 1")]

        public void CheckSellIn(int expectedSellIn, string name)
        {
            IList<Item> items = new List<Item> { new Item { Name = name, SellIn = 0, Quality = 80 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(expectedSellIn, items[0].SellIn);
        }

        [TestCase("Aged Brie",10,1,2, TestName = " of Brie increases by 1 if sellIn > 0")]
        [TestCase("Aged Brie", -10, 1, 3, TestName = " of Brie increases by 2 if sellIn <=0")]
        [TestCase("Aged Brie", -4, 50, 50, TestName = " cannot be more than 50 ")]
        [TestCase("Sulfuras, Hand of Ragnaros", 10, 80, 80, TestName = " of Sulfuras stays the same")]
        [TestCase("Conjured The Elder Wand", 7, 10, 8, TestName = " of Conjured reduced by 2 if in date ")]
        [TestCase("Conjured The Elder Wand", -7, 10, 6, TestName = " of Conjured reduced by 4 if not in date ")]
        [TestCase("The One Ring", 4, 10, 9, TestName = " of all other reduces by 1 if in date ")]
        [TestCase("The One Ring", -4, 10, 8, TestName = " of all other reduces by 2 if not in date ")]
        

        public void CheckQuality(string name, int sellIn, int quality, int expectedQuality)
        {
            IList<Item> items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(expectedQuality, items[0].Quality);
        }
      
        [TestCase(11, 10, 11, TestName = " If Sellin more than 10 quality increases by 1")]
        [TestCase(9, 10, 12, TestName = " If Sellin between 5 and 10 quality increases by 2")]
        [TestCase(5, 10, 13, TestName = " If Sellin less than quality increases by 3")]
        [TestCase(0, 10, 0, TestName = " If Sellin negative then quality goes to 0")]
        [TestCase(5, 50, 50, TestName = " can't have quality more than 50")]

        public void BackStageTests(int sellIn, int quality, int expectedQuality )
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(expectedQuality, items[0].Quality);
        }
        
    }
}
