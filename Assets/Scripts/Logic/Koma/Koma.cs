﻿using System.Collections;
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
    public KomaData Data;
    public KomaType Type { get; private set; }
    public Vector2Int Position { get; private set; }
    public PlayerType PlayerType { get; private set; }
    public int Lv { get ; private set; }

    public void Init(InitData initData)
    {
        Type = initData.Type;
        Lv = initData.Lv;
        PlayerType = initData.PlayerType;
        Data = FixedDataManager.KomaDataProvider.Find(Type, Lv);
        var iconAssetName = Data.GetIconAssetName(PlayerType);
        image.sprite = IconLoader.Load(iconAssetName);
        Move(initData.InitPosition);
    }

    public void Move(Vector2Int position)
    {
        var worldPosition = UIBoard.GetPosition(position);
        transform.position = worldPosition;
        Position = position;
    }

    public class InitData
    {
        public KomaType Type;
        public Vector2Int InitPosition;
        public int Lv = 1;
        public PlayerType PlayerType;

        public InitData(PlaceData.Edit.Place place)
        {
            Type = place.KomaType;
            InitPosition = place.Position;
            Lv = place.Lv;
            PlayerType = place.PlayerType;
        }

        public InitData() { }
    }

    public class Factory : PlaceholderFactory<Koma.InitData, Koma> , IKomaFactory
    {
        
    }
}
