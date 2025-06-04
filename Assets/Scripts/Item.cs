using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public ItemType itemType;
    public int effectValue;
    public Sprite icon;

    public void Initialize(ItemData data)
    {
        itemName = data.itemName;
        itemType = data.itemType;
        effectValue = data.effectValue;
        icon = data.icon;
    }
}