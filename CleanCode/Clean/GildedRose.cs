using System.Collections.Generic;

namespace Clean
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public static bool NameValidaty(string Name)
        {
            return Name != "Aged Brie" 
                && Name != "Backstage passes to a TAFKAL80ETC concert" 
                && Name != "Sulfuras, Hand of Ragnaros";
        }
        public static bool QualityIsPositive(int Quality)
        {
            return Quality > 0;
        }
        public static bool QualityIsLessThanFifty(int Quality)
        {
            return Quality < 50;
        }

        public void UpdateQuality()
        {
            foreach( var item in Items)
            {
                if(NameValidaty(item.Name) && QualityIsPositive(item.Quality))
                {
                    item.Quality--;
                }
                else
                {
                    if(QualityIsLessThanFifty(item.Quality))
                    {
                        item.Quality++;
                    }
                    if(item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.SellIn < 11 && QualityIsLessThanFifty(item.Quality))
                    {
                        item.Quality++;
                    }
                    if(item.SellIn < 6 && QualityIsLessThanFifty(item.Quality))
                    {
                        item.Quality++;
                    }
                }
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn--;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (NameValidaty(item.Name) && QualityIsPositive(item.Quality))
                        {
                            item.Quality--;
                        }
                        else
                        {
                            item.Quality -= item.Quality;
                        }
                    }
                    else
                    {
                        if (QualityIsLessThanFifty(item.Quality))
                        {
                            item.Quality++;
                        }
                    }
                }
            }

        }
    }
}
 