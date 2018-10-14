using UnityEngine;
using Zenject;

public class KomaFactory : IKomaFactory
{
    Koma _komaPrefab;
    DiContainer _container;
    UIBoard _uiBoard;
    public KomaFactory(DiContainer container, UIBoard uiBoard)
    {
        _container = container;
        _uiBoard = uiBoard;
        _komaPrefab = Resources.Load<Koma>("Prefabs/Koma");
    }
    public Koma Create(Koma.InitData param)
    {
        var parent = _uiBoard.GetKomaParent();
        var koma = _container.InstantiatePrefabForComponent<Koma>(_komaPrefab.gameObject, parent);
        koma.Init(param);
        Debug.Log("Create! ; " + koma);
        return koma;
    }
}
