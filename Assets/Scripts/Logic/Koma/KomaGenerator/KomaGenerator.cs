using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class KomaGenerator : IKomaGenerator
{
    Koma _komaPrefab;
    UIBoard _uiBoard;

    public KomaGenerator(Koma komaPrefab, UIBoard uiBoard)
    {
        _komaPrefab = komaPrefab;
        _uiBoard = uiBoard;
    }

    public Koma Create()
    {
        var parent = _uiBoard.GetKomaParent();
        var koma = GameObject.Instantiate<Koma>(_komaPrefab, parent);
        return koma;
    }
}
