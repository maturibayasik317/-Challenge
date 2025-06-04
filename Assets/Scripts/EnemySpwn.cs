using System.Collections.Generic;
using UnityEngine;

public class EnemySpwn : MonoBehaviour
{
    public List<EnemyData> enemyTypes; // ScriptableObject�̃��X�g
    public GameObject enemyPrefab;

    public void SpawnEnemies(List<Vector2Int> positions)
    {
        foreach (var pos in positions)
        {
            // �����_���Ȏ�ނ�I��
            EnemyData data = enemyTypes[Random.Range(0, enemyTypes.Count)];
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(pos.x, 0, pos.y), Quaternion.identity);
            enemy.GetComponent<Enemy>().Initialize(data);
        }
    }
}
