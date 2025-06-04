using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemSpaw : MonoBehaviour
{
    public List<ItemData> itemTypes; // ScriptableObject‚ÌƒŠƒXƒg
    public GameObject itemPrefab;

    public void SpawnItems(List<Vector2Int> positions)
    {
        foreach (var pos in positions)
        {
            ItemData data = itemTypes[Random.Range(0, itemTypes.Count)];
            GameObject item = Instantiate(itemPrefab, new Vector3(pos.x, 0.5f, pos.y), Quaternion.identity);
            item.GetComponent<Item>().Initialize(data);
        }
    }
}
