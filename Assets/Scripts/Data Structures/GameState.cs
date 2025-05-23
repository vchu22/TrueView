using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GameState
{
    public static int currentRound = 0;

    public static Aisle[] itemCatelog;
    public static int[] selectedAisleItemsIdx;

    public static List<AisleItem> shoppingCartItems = new List<AisleItem>();

    public static int lastRoundEthicalProductCount = 0;

    public static void setupAisleProducts(Aisle[] input)
    {
        foreach (Aisle a in input)
        {
            foreach (AisleItem item in a.items)
            {
                item.aisle = a;
            }
        }
        itemCatelog = input;
    }
    public static AisleItem[] getAisleProducts(int idx)
    {
        if (idx < 0 || itemCatelog.Length <= idx)
        {
            return null;
        }
        return itemCatelog[idx].items;
    }
    public static AisleItem[] getAisleProducts(string aisleName)
    {
        foreach (Aisle a in itemCatelog)
        {
            if (a.name == aisleName)
            {
                return a.items;
            }
        }
        return null;
    }
    public static string[] getAisleNameList()
    {
        return itemCatelog.Select(itemCatelog => itemCatelog.name).ToArray();
    }
    public static string getAisleName(int i)
    {
        return getAisleNameList()[i];
    }
    public static int getNumberOfAisles()
    {
        return itemCatelog.Length;
    }
}
