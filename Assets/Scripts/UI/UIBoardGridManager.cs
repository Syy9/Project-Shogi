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

    Button[] _buttons;
    void Awake()
    {
        _buttons = GetComponentsInChildren<Button>();
        for (int i = 0; i < _buttons.Length; i++)
        {
            int x = i % ROW_COUNT;
            int y = i / COLUMN_COUNT;
            _buttons[i].onClick.AddListener(() => {
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

    public void SetHightligh(Vector2Int position, bool isHighLight)
    {
        if (_buttons == null)
            return;
        var index = position.y * COLUMN_COUNT + position.x;
        var button = _buttons[index];
        button.targetGraphic.color = isHighLight ? Color.gray : Color.white;
    }
}
