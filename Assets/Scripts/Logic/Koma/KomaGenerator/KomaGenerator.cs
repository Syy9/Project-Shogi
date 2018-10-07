using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class KomaGenerator : IKomaGenerator
{
    DiContainer _container;
    Koma _komaPrefab;
    UIBoard _uiBoard;

    [Inject]
    public KomaGenerator(DiContainer container, Koma komaPrefab, UIBoard uiBoard)
    {
        _container = container;
        _komaPrefab = komaPrefab;
        _uiBoard = uiBoard;
    }

    public Koma Create()
    {
        var parent = _uiBoard.GetKomaParent();
        var koma = GameObject.Instantiate<Koma>(_komaPrefab, parent);
        _container.Inject(koma);
        return koma;
    }
}
