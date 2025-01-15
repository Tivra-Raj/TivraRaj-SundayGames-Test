using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Level))]
public class LevelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Level level = (Level)target;

        // Track the old values of rows and columns
        int oldRows = level.Rows;
        int oldColoms = level.Coloms;

        // Draw the default inspector for general properties
        DrawDefaultInspector();

        // Check if rows or columns have been changed
        if (oldRows != level.Rows || oldColoms != level.Coloms)
        {
            level.InitializeGrid();  // Recreate the grid with updated dimensions
            EditorUtility.SetDirty(level);
        }

        // Only show the button if rows and coloms are greater than zero
        if (level.Rows > 0 && level.Coloms > 0)
        {
            if (GUILayout.Button("Create Grid"))
            {
                level.InitializeGrid();  // Create or recreate the grid with updated dimensions
                EditorUtility.SetDirty(level);
            }

            // Render the grid editor if it's initialized
            if (level.blockIndices != null)
            {
                EditorGUILayout.LabelField("Grid Editor", EditorStyles.boldLabel);

                for (int row = 0; row < level.Rows; row++)
                {
                    EditorGUILayout.BeginHorizontal();

                    for (int col = 0; col < level.Coloms; col++)
                    {
                        int blockIndex = level.GetBlockAt(row, col) != null
                            ? System.Array.IndexOf(level.Blocks, level.GetBlockAt(row, col))
                            : -1;

                        blockIndex = EditorGUILayout.Popup(blockIndex + 1, GetBlockNames(level.Blocks)) - 1;

                        level.SetBlockAt(row, col, blockIndex);
                    }

                    EditorGUILayout.EndHorizontal();
                }
            }
            else
            {
                EditorGUILayout.HelpBox("Grid not initialized. Press 'Create Grid' to create it.", MessageType.Warning);
            }
        }
        else
        {
            EditorGUILayout.HelpBox("Set valid row and column values to create the grid.", MessageType.Warning);
        }

        // Save changes
        if (GUI.changed)
        {
            EditorUtility.SetDirty(level);
        }
    }

    private string[] GetBlockNames(GameObject[] blocks)
    {
        if (blocks == null || blocks.Length == 0)
            return new string[] { "None" };

        string[] names = new string[blocks.Length + 1];
        names[0] = "None";

        for (int i = 0; i < blocks.Length; i++)
        {
            names[i + 1] = blocks[i] != null ? blocks[i].name : "Unnamed";
        }

        return names;
    }

}