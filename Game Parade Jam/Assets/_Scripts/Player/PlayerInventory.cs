using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;
    public ItemData currentItem;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public bool HasItem => currentItem != null;

    public void Hold(ItemData item)
    {
        currentItem = item;
    }

    public void Drop()
    {
        currentItem = null;
    }

    public bool IsHoldingExtinguisher()
    {
        return currentItem != null && currentItem.itemName == "FireExtinggushier";
    }

    public bool IsHoldingCandy()
    {
        return currentItem != null && currentItem.itemName == "Candy";
    }

    public bool IsHoldingMedicine()
    {
        return currentItem != null && currentItem.itemName == "Medicine";
    }

    public bool IsHoldingDiary()
    {
        return currentItem != null && currentItem.itemName == "Diary";
    }

    public bool IsHoldingTea()
    {
        return currentItem != null && currentItem.itemName == "Tea";
    }
}
