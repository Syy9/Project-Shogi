using UnityEngine;
using Zenject;

public class KomaFactory : IKomaFactory
{
    Koma _komaPrefab;
    DiContainer _container;
    IUIBoard _uiBoard;
    public KomaFactory(DiContainer container, IUIBoard uiBoard)
    {
        _container = container;
        _uiBoard = uiBoard;
        _komaPrefab = Resources.Load<Koma>("Prefabs/Koma");
    }
    public Koma Create(Koma.InitData param)
    {
        var koma = _container.InstantiatePrefabForComponent<Koma>(_komaPrefab.gameObject, _uiBoard.KomaParent);
        koma.Init(param);
        Debug.Log("Create! ; " + koma);
        return koma;
    }
}
