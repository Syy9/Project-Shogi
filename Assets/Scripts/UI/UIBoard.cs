using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIBoard
{
    Transform KomaParent { get; }
    Action<Vector2Int> OnSelect { get; set; }
    Vector2 GetPosition(int x, int y);
}

public class UIBoard : MonoBehaviour, IUIBoard {
    [SerializeField] Transform komaParent;
    [SerializeField] UIBoardGridManager boardInput;

    public Transform KomaParent { get { return komaParent; } }
    public Action<Vector2Int> OnSelect { get; set; }

    void Awake()
    {
        boardInput.OnSelect += (value) => {
            OnSelect.Call(value);
        };
    }

    public Vector2 GetPosition(int x, int y)
    {
        return boardInput.GetPosition(x, y);
    }
}
