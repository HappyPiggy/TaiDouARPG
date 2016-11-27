using UnityEngine;
using System.Collections;

public class InventoryItem
{

    private Inventory inventory;
    private int level;
    private int count;

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public int Count
    {
        set { count = value; }
        get { return count; }
    }

    public Inventory Inventory
    {
        set { inventory = value; }
        get { return inventory; }
    }

}
