using UnityEngine;

public class RogueManager : MonoBehaviour
{
    public GameObject playerPrefab, enemyPrefab, floorPrefab, wallPrefab;
    public string csvFileName = "map"; // Resources/map.csv

    private string[,] mapData;
    private int width, height;
    private Vector2Int playerPos, enemyPos;
    private GameObject playerObj, enemyObj;

    void Start()
    {
        LoadMapFromCSV();
        SpawnEntities();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) TryPlayerMove(Vector2Int.up);
        if (Input.GetKeyDown(KeyCode.S)) TryPlayerMove(Vector2Int.down);
        if (Input.GetKeyDown(KeyCode.A)) TryPlayerMove(Vector2Int.left);
        if (Input.GetKeyDown(KeyCode.D)) TryPlayerMove(Vector2Int.right);
    }

    void LoadMapFromCSV()
    {
        var csv = Resources.Load<TextAsset>(csvFileName);
        var lines = csv.text.Split(new[] { "\r\n", "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
        height = lines.Length;
        width = lines[0].Split(',').Length;
        mapData = new string[height, width];

        for (int y = 0; y < height; y++)
        {
            var cells = lines[y].Split(',');
            for (int x = 0; x < width; x++)
            {
                string c = cells[x].Trim();
                mapData[y, x] = c;

                Vector3 pos = new Vector3(x, 0, -y);
                if (c == "W") Instantiate(wallPrefab, pos + Vector3.up * 0.5f, Quaternion.identity, transform);
                else Instantiate(floorPrefab, pos, Quaternion.identity, transform);

                if (c == "P") playerPos = new Vector2Int(x, y);
                if (c == "E") enemyPos = new Vector2Int(x, y);
            }
        }
    }

    void SpawnEntities()
    {
        playerObj = Instantiate(playerPrefab, new Vector3(playerPos.x, 0.5f, -playerPos.y), Quaternion.identity);
        enemyObj = Instantiate(enemyPrefab, new Vector3(enemyPos.x, 0.5f, -enemyPos.y), Quaternion.identity);
    }

    void TryPlayerMove(Vector2Int dir)
    {
        Vector2Int next = playerPos + dir;
        if (CanMove(next))
        {
            playerPos = next;
            playerObj.transform.position = new Vector3(playerPos.x, 0.5f, -playerPos.y);
            // ìGÇ‡1âÒà⁄ìÆ
            EnemyMove();
        }
    }

    bool CanMove(Vector2Int pos)
    {
        if (pos.x < 0 || pos.x >= width || pos.y < 0 || pos.y >= height) return false;
        return mapData[pos.y, pos.x] != "W";
    }

    void EnemyMove()
    {
        Vector2Int delta = playerPos - enemyPos;
        Vector2Int move = Vector2Int.zero;
        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            move.x = delta.x > 0 ? 1 : -1;
        else if (delta.y != 0)
            move.y = delta.y > 0 ? 1 : -1;

        Vector2Int next = enemyPos + move;
        if (CanMove(next) && next != playerPos) // ÉvÉåÉCÉÑÅ[Ç∆îÌÇÁÇ»Ç¢ÇÊÇ§Ç…
        {
            enemyPos = next;
            enemyObj.transform.position = new Vector3(enemyPos.x, 0.5f, -enemyPos.y);
        }
    }
}
