using UnityEngine;

[CreateAssetMenu(menuName = "Roguelike/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int baseHP;
    public int baseAttack;
    public float moveSpeed;
    public Sprite icon;
    public GameObject prefab;

}
