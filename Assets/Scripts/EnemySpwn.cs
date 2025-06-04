using System.Collections.Generic;
using UnityEngine;

public class EnemySpwn : MonoBehaviour
{
    public List<EnemyData> enemyTypes; // ScriptableObjectのリスト
    public GameObject enemyPrefab;

    public void SpawnEnemies(List<Vector2Int> positions)
    {
        foreach (var pos in positions)
        {
            // ランダムな種類を選択
            EnemyData data = enemyTypes[Random.Range(0, enemyTypes.Count)];
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(pos.x, 0, pos.y), Quaternion.identity);
            enemy.GetComponent<Enemy>().Initialize(data);
        }
    }
}
