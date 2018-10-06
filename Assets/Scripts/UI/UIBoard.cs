using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBoard : MonoBehaviour {
    [SerializeField] Transform komaParent;

    public Transform GetKomaParent()
    {
        return komaParent;
    }
}
