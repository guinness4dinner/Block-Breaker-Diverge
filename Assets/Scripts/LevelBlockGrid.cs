using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Block Grid")]
public class LevelBlockGrid : ScriptableObject 
{
    [TextArea(1, 2)] [SerializeField] string row1Types;
    [TextArea(1, 2)] [SerializeField] string row2Types;
    [TextArea(1, 2)] [SerializeField] string row3Types;
    [TextArea(1, 2)] [SerializeField] string row4Types;
    [TextArea(1, 2)] [SerializeField] string row5Types;
    [TextArea(1, 2)] [SerializeField] string row6Types;
    [TextArea(1, 2)] [SerializeField] string row7Types;
    [TextArea(1, 2)] [SerializeField] string row8Types;
    [TextArea(1, 2)] [SerializeField] string row9Types;
    [TextArea(1, 2)] [SerializeField] string row10Types;
    [TextArea(1, 2)] [SerializeField] string row11Types;
    [TextArea(1, 2)] [SerializeField] string row12Types;
    [SerializeField] Transform[] blockTypes;
    [TextArea(1, 2)] [SerializeField] string row1Colors;
    [TextArea(1, 2)] [SerializeField] string row2Colors;
    [TextArea(1, 2)] [SerializeField] string row3Colors;
    [TextArea(1, 2)] [SerializeField] string row4Colors;
    [TextArea(1, 2)] [SerializeField] string row5Colors;
    [TextArea(1, 2)] [SerializeField] string row6Colors;
    [TextArea(1, 2)] [SerializeField] string row7Colors;
    [TextArea(1, 2)] [SerializeField] string row8Colors;
    [TextArea(1, 2)] [SerializeField] string row9Colors;
    [TextArea(1, 2)] [SerializeField] string row10Colors;
    [TextArea(1, 2)] [SerializeField] string row11Colors;
    [TextArea(1, 2)] [SerializeField] string row12Colors;
    [SerializeField] Color[] colors;


    public int[][] GetBlockTypesIntArray()
    {
        int[][] result = new int[12][];
        string[] rowStrings = new string[] { row1Types, row2Types, row3Types, row4Types, row5Types, row6Types, row7Types, row8Types, row9Types, row10Types, row11Types, row12Types };

        for (int row = 0; row < 12; row++)
        {
            result[row] = StringToInt(rowStrings[row]); 
        }

            return result;
    }

    public Transform[] GetBlockTypes()
    {
        return blockTypes;
    }

    public int[][] GetBlockColorsIntArray()
    {
        int[][] result = new int[12][];
        string[] rowStrings = new string[] { row1Colors, row2Colors, row3Colors, row4Colors, row5Colors, row6Colors, row7Colors, row8Colors, row9Colors, row10Colors, row11Colors, row12Colors };

        for (int row = 0; row < 12; row++)
        {
            result[row] = StringToInt(rowStrings[row]);
        }

        return result;
    }

    public Color[] GetColors()
    {
        return colors;
    }

    private int[] StringToInt(string stringofints)
    {
        
        string[] intStringSplit = stringofints.Split(',') ;
        int[] result = new int[intStringSplit.Length];
        for (int i = 0; i < intStringSplit.Length; i++)
        {
            //parse and store each value into int[] to be returned
            result[i] = int.Parse(intStringSplit[i]);
        }

        return result;
    }

}
