using System.Collections.Generic;
using UnityEngine;

public class MapCreate : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public GameObject floorPrefab;
    public GameObject wallPrefab;

    private CellType[,] grid;

    public Vector2Int playerSpawnPos;
    public List<Vector2Int> enemySpawnPositions = new List<Vector2Int>();
    public List<Vector2Int> itemSpawnPositions = new List<Vector2Int>();

    public void Generate()
    {
        grid = new CellType[width, height];

        // 1. �S�Z����Wall�ŏ�����
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                grid[x, y] = CellType.Wall;
            }
        }

        // 2. �����_���ȕ��������i��: ������5x5��Floor�̈�j
        for (int x = 2; x < width - 2; x++)
        {
            for (int y = 2; y < height - 2; y++)
            {
                grid[x, y] = CellType.Floor;
            }
        }

        // 3. �v���C���[�E�G�E�A�C�e���̃X�|�[���ʒu������
        playerSpawnPos = new Vector2Int(width / 2, height / 2);
        grid[playerSpawnPos.x, playerSpawnPos.y] = CellType.PlayerSpawn;

        // �G�X�|�[���ʒu�������_����3��
        enemySpawnPositions.Clear();
        for (int i = 0; i < 3; i++)
        {
            Vector2Int pos;
            do
            {
                pos = new Vector2Int(Random.Range(2, width - 2), Random.Range(2, height - 2));
            } while (grid[pos.x, pos.y] != CellType.Floor || enemySpawnPositions.Contains(pos));
            grid[pos.x, pos.y] = CellType.EnemySpawn;
            enemySpawnPositions.Add(pos);
        }

        // �A�C�e���X�|�[���ʒu�������_����2��
        itemSpawnPositions.Clear();
        for (int i = 0; i < 2; i++)
        {
            Vector2Int pos;
            do
            {
                pos = new Vector2Int(Random.Range(2, width - 2), Random.Range(2, height - 2));
            } while (grid[pos.x, pos.y] != CellType.Floor || itemSpawnPositions.Contains(pos));
            grid[pos.x, pos.y] = CellType.ItemSpawn;
            itemSpawnPositions.Add(pos);
        }

        // 4. ���ۂɃv���n�u��z�u�i�G�f�B�^�[��Q�[����ʂɏo���ꍇ�j
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 pos = new Vector3(x, 0, y);
                if (grid[x, y] == CellType.Wall)
                {
                    Instantiate(wallPrefab, pos, Quaternion.identity, transform);
                }
                else
                {
                    Instantiate(floorPrefab, pos, Quaternion.identity, transform);
                }
            }
        }
    }
}
