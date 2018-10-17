using System.Collections;
using System.Collections.Generic;
using MasterData;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[DisallowMultipleComponent]
public class Koma : MonoBehaviour {
    [Inject] IFixedDataManager FixedDataManager;
    [Inject] IUIBoard UIBoard;
    [Inject] KomaIconLoader IconLoader;
    [SerializeField] Image image;
    KomaType Type;

    public void Init(InitData initData)
    {
        Type = initData.Type;
        var komaData = FixedDataManager.KomaDataProvider.Find(initData.Type);
        image.sprite = IconLoader.Load(komaData.IconAssetName);
        Move(initData.InitPosition.x, initData.InitPosition.y);
    }

    public void Move(int x, int y)
    {
        var position = UIBoard.GetPosition(x, y);
        transform.position = position;
    }

    public class InitData
    {
        public KomaType Type;
        public Vector2Int InitPosition;
    }

    public class Factory : PlaceholderFactory<Koma.InitData, Koma> , IKomaFactory
    {
        
    }
}
