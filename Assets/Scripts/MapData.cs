using UnityEngine;

[CreateAssetMenu(menuName = "Roguelike/MapData")]

public class MapData : ScriptableObject
{
    public string mapName;
    public int width;
    public int height;
    public GameObject[] possibleEnemies;
    public GameObject[] possibleItems;
}
