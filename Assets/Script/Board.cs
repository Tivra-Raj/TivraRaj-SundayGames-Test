using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private LevelHolder levelHolder;
    [SerializeField] private int level;

    private int rows;
    private int columns;
    [SerializeField] private float cellSize = 1.0f;
    [SerializeField] private GameObject tilePefab;

    private BackgroundTile[,] allTiles;

    private void Awake()
    {
        if(levelHolder != null)
        {
            if (levelHolder.Levels[level] != null)
            {
                rows = levelHolder.Levels[level].Rows;
                columns = levelHolder.Levels[level].Coloms;
            }
        }
    }

    private void Start()
    {
        allTiles = new BackgroundTile[rows, columns];
        CreateBoard();
    }

    private void CreateBoard()
    {
        for (int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                //Vector2 tilePosition = new Vector2(j * cellSize, i * cellSize);
                //GameObject tile = Instantiate(tilePefab, tilePosition, Quaternion.identity);
                //tile.transform.SetParent(this.transform, false);

                GameObject blockPrefab = levelHolder.Levels[level].GetBlockAt(i, j);
                if (blockPrefab != null)
                {
                    Vector3 blockPosition = new Vector3(j * cellSize, -i * cellSize, 0);
                    Instantiate(blockPrefab, blockPosition, Quaternion.identity, this.transform);
                }

            }
        }
    }

}
