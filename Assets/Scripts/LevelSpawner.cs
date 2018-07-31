using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{

    [SerializeField] LevelBlockGrid levelBlockGrid;

    [System.NonSerialized] public Transform[] blockTypes;
    [System.NonSerialized] public Color[] colors;

    // Use this for initialization
    void Start ()
    {
        //Grab Block Types and Block Colors from Level Scriptable Object
        int[][] rows = levelBlockGrid.GetBlockTypesIntArray();
        int[][] colorrows = levelBlockGrid.GetBlockColorsIntArray();
        blockTypes = levelBlockGrid.GetBlockTypes();
        colors = levelBlockGrid.GetColors();

        //Spawn the blocks, row by row
        for (int row = 0; row < 12; row++)
        {
            SpawnRow(ref rows[row], ref colorrows[row], ref row);
        }
    }
    
    //Method for spawning one row of blocks
    private void SpawnRow(ref int[] rows, ref int[] colorrows, ref int row)
    {
        int index = 0;
        foreach (int element in rows)  //Get the Block Type
        {
            if (element != 0)
            {
                var blockcolor = colorrows[index];  //Get the Block Color
                SpawnBlock(row, index, element, blockcolor); //Spawn One Block
            }
            index++;
        }      
    }

    //Method for Spawning a single block of a type (prefab) and color using on the grid by col and row.
    //These all use indexes into arrays of their type.
    private void SpawnBlock(int row, int col, int blocktype, int blockcolor)
    {
        Transform block;
        block = Instantiate(blockTypes[blocktype - 1], new Vector3(col + 0.64f, 10.85f - (row * 0.5f), 8.8f - 0.8f * row + 0.16f - col * 0.05f), Quaternion.identity);
        if (blockcolor != 0)
        {
            block.GetComponent<SpriteRenderer>().color = colors[blockcolor - 1];
        }
        
    }

}
