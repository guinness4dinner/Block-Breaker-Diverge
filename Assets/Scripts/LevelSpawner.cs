using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{

    [SerializeField] int[] row1 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    [SerializeField] int[] row2 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    [SerializeField] int[] row3 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    [SerializeField] int[] row4 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    [SerializeField] int[] row5 = { 0, 0, 0, 2, 0, 0, 0, 1, 1, 0, 0, 0, 2, 0, 0, 0 };
    [SerializeField] int[] row6 = { 0, 0, 2, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 2, 0, 0 };
    [SerializeField] int[] row7 = { 0, 2, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 2, 0 };
    [SerializeField] int[] row8 = { 2, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 2 };
    [SerializeField] int[] row9 = { 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 };
    [SerializeField] int[] row10 = { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 };
    [SerializeField] int[] row11 = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 };
    [SerializeField] int[] row12 = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    [SerializeField] Transform[] blockTypes;

    

    // Use this for initialization
    void Start ()
    {
        int[][] rows = new int[][] { row1, row2, row3, row4, row5, row6, row7, row8, row9, row10, row11, row12 };

        for (int row = 0; row < 12; row++)
        {
            SpawnRow(ref rows[row], ref row);
        }
    }

    private void SpawnRow(ref int[] rows, ref int row)
    {
        int index = 0;
        foreach (int element in rows)
        {
            if (element != 0)
            {
                SpawnBlock(index, element, row);
            }
            index++;
        }      
    }

    private void SpawnBlock(int index, int element, int row)
    {    
            Instantiate(blockTypes[element-1], new Vector3(index + 4.5f, 10.35f - (row * 0.35f), 0), Quaternion.identity);
    }

}
