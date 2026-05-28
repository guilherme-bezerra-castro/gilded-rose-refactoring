using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            UpdateItem(item);
        }
    }

    private void UpdateItem(Item item)
    {
        if (item.Name != "Sulfuras, Hand of Ragnaros")
            item.SellIn--;

        switch (item.Name)
        {
            case "Aged Brie":
                UpdateAgedBrie(item);
                break;
            case "Sulfuras, Hand of Ragnaros":
                // Legendary item
                break;
            case "Backstage passes to a TAFKAL80ETC concert":
                UpdateBackstagePass(item);
                break;
            case "Conjured Mana Cake":
                UpdateConjured(item);
                break;
            default:
                UpdateNormalItem(item);
                break;
        }
    }

    private void UpdateNormalItem(Item item)
    {
        int degradation = item.SellIn < 0 ? 2 : 1;
        item.Quality = Math.Max(0, item.Quality - degradation);
    }

    private void UpdateAgedBrie(Item item)
    {
        int increase = item.SellIn < 0 ? 2 : 1;
        item.Quality = Math.Min(50, item.Quality + increase);
    }

    private void UpdateBackstagePass(Item item)
    {

        if (item.SellIn < 0)
        {
            item.Quality = 0;
            return;
        }

        int increase = item.SellIn < 5 ? 3 : item.SellIn < 10 ? 2 : 1;
        item.Quality = Math.Min(50, item.Quality + increase);
    }

    private void UpdateConjured(Item item)
    {
        int degradation = item.SellIn < 0 ? 4 : 2;
        item.Quality = Math.Max(0, item.Quality - degradation);
    }
}
