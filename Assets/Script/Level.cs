using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Create Level / Level")]
public class Level : ScriptableObject
{
    [Header("Board dimension")]
    [SerializeField] private int rows;
    [SerializeField] private int coloms;

    [Header ("Available blocks")]
    [SerializeField] private GameObject[] blocks;

    [Header("Grid Data")]
    public int[,] blockIndices; // Stores the index of the block for each cell

    public int Rows => rows;

    public int Coloms => coloms;

    public GameObject[] Blocks => blocks;
   /* public int[,] BlockIndices
    {
        get => blockIndices;
        set => blockIndices = value;
    }*/

    // Get the block prefab for a specific cell
    public GameObject GetBlockAt(int row, int col)
    {
        if (blockIndices == null || row < 0 || col < 0 || row >= rows || col >= coloms)
            return null;

        int blockIndex = blockIndices[row, col];
        return blockIndex >= 0 && blockIndex < blocks.Length ? blocks[blockIndex] : null;
    }

    public void SetBlockAt(int row, int col, int blockIndex)
    {
        if (blockIndices == null)
        {
            Debug.LogError("Grid not initialized. Please initialize the grid first.");
            return;
        }

        if (row >= 0 && col >= 0 && row < rows && col < coloms)
            blockIndices[row, col] = blockIndex;
    }

    public void InitializeGrid()
    {
        if (rows <= 0 || coloms <= 0)
        {
            Debug.LogError("Rows and columns must be greater than zero before initializing the grid.");
            return;
        }

        blockIndices = new int[rows, coloms];

    }
}