using UnityEngine;
using System.IO;

public class MapCreate : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject itemPrefab;
    public GameObject floorPrefab;
    public GameObject wallPrefab;

    public string csvFileName = "MapDate"; // Resources/Name.csv

    void Start()
    {
        CreateMapFromCSV();
    }

    void CreateMapFromCSV()
    {
        TextAsset csvFile = Resources.Load<TextAsset>(csvFileName);
        if (csvFile == null)
        {
            Debug.LogError("CSVƒtƒ@ƒCƒ‹‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ: " + csvFileName);
            return;
        }

        string[] lines = csvFile.text.Split(new[] { "\r\n", "\n" }, System.StringSplitOptions.None);

        for (int y = 0; y < lines.Length; y++)
        {
            string[] cells = lines[y].Split(',');

            for (int x = 0; x < cells.Length; x++)
            {
                Vector3 pos = new Vector3(x, 0, -y); 

                string cell = cells[x].Trim();

                // °‚Íí‚É¶¬
                Instantiate(floorPrefab, pos, Quaternion.identity, transform);

                switch (cell)
                {
                    case "W":
                        Instantiate(wallPrefab, pos + Vector3.up * 0.5f, Quaternion.identity, transform);
                        break;
                    case "P":
                        Instantiate(playerPrefab, pos + Vector3.up * 0.5f, Quaternion.identity);
                        break;
                    case "E":
                        Instantiate(enemyPrefab, pos + Vector3.up * 0.5f, Quaternion.identity, transform);
                        break;
                    case "I":
                        Instantiate(itemPrefab, pos + Vector3.up * 0.5f, Quaternion.identity, transform);
                        break;
                }
            }
        }
    }
}