using System.Collections.Generic;

namespace GildedRoseKata
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
                if (Items[i].Name == "Aged Brie")
                {
                    Items[i].Quality = BussinesBrie(Items[i].Quality);
                    Items[i].SellIn = Items[i].SellIn - 1;
                }
                else if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].Quality = BussinesSulfuras(Items[i].Quality);
                }
                else if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    Items[i].Quality = BussinesBackstage(Items[i].Quality, Items[i].SellIn);
                    Items[i].SellIn = Items[i].SellIn - 1;
                }
                else if (Items[i].Name == "Conjured Mana Cake")
                {
                    Items[i].Quality = BussinesConjured(Items[i].Quality);
                    Items[i].SellIn = Items[i].SellIn - 1;
                }
                else
                {
                    Items[i].Quality = Bussines(Items[i].Quality);
                    Items[i].SellIn = Items[i].SellIn - 1;
                }
            }
        }

        public int BussinesBrie(int quality)
        {
            quality = Counter(1, quality, 1);
            return quality;
        }

        public int BussinesSulfuras(int quality)
        {
            quality = 80;
            return quality;
        }

        public int BussinesBackstage(int quality, int sellin)
        {
            if (sellin <= 10)
            {
                quality = Counter(2, quality, 1);
            }
            else if (sellin <= 5)
            {
                quality = Counter(3, quality, 1);
            }
            else if (sellin < 0)
            {
                quality = 0;
            }
            return quality;
        }

        public int BussinesConjured(int quality)
        {
            quality = Counter(2, quality, 0);
            return quality;
        }

        public int Bussines(int quality)
        {
            quality = Counter(1, quality, 0);
            return quality;
        }

        public int Counter(int value, int quality, int aux)
        {
            if (aux == 1)
            {
                if (quality < 50)
                {
                    quality += value;
                }
            }
            else
            {
                if (quality < 50)
                {
                    quality -= value;
                }
            }

            return quality;
        }

        //fim
    }
}