using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBoardGridManager : MonoBehaviour {
    public const int COLUMN_COUNT = 9;
    public const int ROW_COUNT = 9;
    public Vector2 GetPosition(int x, int y)
    {
        int index = y * COLUMN_COUNT + x;
        var grid = transform.GetChild(index);
        return grid.transform.position;
    }
}
