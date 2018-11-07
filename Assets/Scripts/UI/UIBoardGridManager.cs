using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBoardGridManager : MonoBehaviour
{
    public const int COLUMN_COUNT = 9;
    public const int ROW_COUNT = 9;

    public event Action<Vector2Int> OnSelect;

    void Awake()
    {
        var buttons = GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            int x = i % COLUMN_COUNT;
            int y = i / ROW_COUNT;
            buttons[i].onClick.AddListener(() => {
                OnSelect.Call(new Vector2Int(x, y));
            });
        }
    }

    public Vector2 GetPosition(Vector2Int position)
    {
        int index = position.y * COLUMN_COUNT + position.x;
        var grid = transform.GetChild(index);
        return grid.transform.position;
    }
}
