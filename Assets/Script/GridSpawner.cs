using UnityEngine;

namespace Assets.Script
{
    public class GridSpawner : MonoBehaviour
    {
        [SerializeField] private Level levelData; // Reference to the Level scriptable object
        [SerializeField] private Vector2 slotSpacing = new Vector2(1f, 1f); // Spacing between slots

        // Optional: Automatically spawn the grid on start
        private void Start()
        {
            SpawnGrid();
        }

        public void SpawnGrid()
        {
            if (levelData == null)
            {
                Debug.LogError("Level data is not assigned!");
                return;
            }

            // Get grid dimensions from the Level scriptable object
            int rows = levelData.Rows;
            int cols = levelData.Coloms;

            int height = 2;//levelData.Height; // Get the height of the grid

            // Loop through the height to spawn multiple grids
            for (int h = 0; h < height; h++)
            {
                Vector3 heightOffset = new Vector3(0, 0, h); // Offset for each grid layer

                // Loop through the grid and spawn slots
                int index = 0;
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        // Calculate the position of the slot
                        Vector3 position = new Vector3(col * slotSpacing.x, row * slotSpacing.y, 0) + heightOffset;

                        // Instantiate the slot prefab
                        Slot slot = Instantiate(levelData.SlotPrefab, position, Quaternion.identity, this.transform);

                        // Rename the slot
                        slot.name = $"Slot_{row}_{col}_Height_{h}_Level_{levelData.name}";

                        // Activate the brick based on the type from Level data
                        if (index < levelData.GridData.Length)
                        {
                            slot.ActivateBrick(levelData.GridData[index].brickType);
                        }

                        index++;
                    }
                }

                Debug.Log("Grid layer spawned successfully for level: " + levelData.name + " at height: " + h);
            }

            //Debug.Log("Grid spawned successfully!");
        }
    }
}