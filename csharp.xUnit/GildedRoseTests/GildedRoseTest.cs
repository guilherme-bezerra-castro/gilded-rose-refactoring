using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    // Normal Item
    [Fact]
    public void NormalItem_BeforeSellingQualityDecreases1()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 10 } };
        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();

        Assert.Equal(9, Items[0].Quality);
        Assert.Equal(4, Items[0].SellIn);
    }

    [Fact]
    public void NormalItem_AfterSellingQualityDecreases2()
    {
        var items = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(8, items[0].Quality);
        Assert.Equal(-1, items[0].SellIn);
    }

    [Fact]
    public void NormalItem_QualityIsNeverNegative()
    {
        var items = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 0 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void NormalItem_AfterSellingQualityIsNotNegative()
    {
        var items = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = -1, Quality = 1 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(0, items[0].Quality);
    }

    // Aged Brie
    [Fact]
    public void AgedBrie_QualityIncreases1PerDay()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(21, items[0].Quality);
    }

    [Fact]
    public void AgedBrie_QualityIsAlwaysLessThan50()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(50, items[0].Quality);
    }

    [Fact]
    public void AgedBrie_AfterSellingQualityKeepsIncreasing2xFaster()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(22, items[0].Quality);
    }

    // Sulfuras
    [Fact]
    public void Sulfuras_QualityNeverChanges()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(80, items[0].Quality);
    }

    [Fact]
    public void Sulfuras_SellInNeverChanges()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(5, items[0].SellIn);
    }

    // Backstage Pass
    [Fact]
    public void BackstagePass_MoreThan10DaysQualityIncreases1()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(21, items[0].Quality);
    }

    [Fact]

    public void BackstagePass_10DaysOrLessQualityIncreases2()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(22, items[0].Quality);
    }

    [Fact]
    public void BackstagePass_5DaysOrLessQualityIncreases3()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(23, items[0].Quality);
    }

    [Fact]
    public void BackstagePass_AfterShowQualityIsZero()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 40 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void BackstagePass_QualityIsAlwaysLessThan50()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(50, items[0].Quality);
    }

    // Conjured
    [Fact]
    public void Conjured_BeforeSellingQualityDecreases2()
    {
        var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(8, items[0].Quality);
    }

    [Fact]
    public void Conjured_AfterSellingQualityDecreases4()
    {
        var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        // After selling, it happens 2x faster than the usual, so (-2) * 2 = -4
        Assert.Equal(6, items[0].Quality);
    }

    [Fact]
    public void Conjured_QualityIsNotNegative()
    {
        var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 1 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(0, items[0].Quality);
    }
}