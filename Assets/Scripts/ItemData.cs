using UnityEngine;

public enum ItemType { Heal, AttackBuf, DefenseBuf}

[CreateAssetMenu(menuName ="Roguelike/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public ItemType titemype;
    public int effectValue;
    public Sprite icon;
    public GameObject prefab;
}
