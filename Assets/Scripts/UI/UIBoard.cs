using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBoard : MonoBehaviour {
    [SerializeField] Transform komaParent;
    [SerializeField] UIBoardGridManager boardInput;

    public Transform GetKomaParent()
    {
        return komaParent;
    }

    public UIBoardGridManager GetBoardInput()
    {
        return boardInput;
    }
}
