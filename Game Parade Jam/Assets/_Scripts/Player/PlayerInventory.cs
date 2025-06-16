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
        return currentItem != null && currentItem.isExtinguisher;
    }
}
