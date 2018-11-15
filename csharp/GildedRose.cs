using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                switch (Items[i].Name)
                {
                    case "Aged Brie":
                        Items[i] = ChangeItemQualityAndSellIn(Items[i],1);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        Items[i] = ChangeBackstageQualityAndSellIn(Items[i]);
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        break;
                    default:
                        if (Items[i].Name.Contains("Conjured"))
                        {
                            Items[i] = ChangeItemQualityAndSellIn(Items[i], -2);
                        }
                        else
                        {
                            Items[i] = ChangeItemQualityAndSellIn(Items[i], -1);
                        }
                        break;
                }
            }
        }

        private Item ChangeItemQualityAndSellIn(Item item, int increment)
        {
            item = item.SellIn > 0 ? ChangeItemQuality(increment, item) : ChangeItemQuality(increment*2, item);
            
            return ChangeSellIn(item);
        }

        
        private Item ChangeItemQuality(int increment,Item item)
        {
            item.Quality += increment;

            item.Quality = Math.Min(item.Quality, 50);
            item.Quality = Math.Max(item.Quality, 0);

            return item;
        }

        private Item ChangeBackstageQualityAndSellIn(Item item)
        {
            if (item.SellIn > 10)
            {
                item = ChangeItemQuality(1, item);
            }

            if (item.SellIn < 11 && item.SellIn >= 6)
            {
                item = ChangeItemQuality(2, item);
            }

            if (item.SellIn >= 0 && item.SellIn < 6)
            {
                item = ChangeItemQuality(3, item);
            }

            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
            
            item = ChangeSellIn(item);
            return item;
        }

        private Item ChangeSellIn(Item item)
        {
            item.SellIn += -1;
            return item;
        }
    }
}
