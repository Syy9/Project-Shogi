﻿using System.Collections;
using System.Collections.Generic;
using MasterData;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[DisallowMultipleComponent]
public class Koma : MonoBehaviour {
    [Inject] IFixedDataManager FixedDataManager;
    [Inject] UIBoardGridManager UIBoardGridManager;
    [Inject] KomaIconLoader IconLoader;
    [SerializeField] Image image;
    KomaType Type;

    IEnumerator Start()
    {
        Move(0, 0);
        for (int x = 0; x < 9; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                yield return new WaitForSeconds(1);
                Move(x, y);
            }
        }
    }

    public void Init(Data initData)
    {
        Type = initData.Type;
        var komaData = FixedDataManager.KomaDataProvider.Find(initData.Type);
        image.sprite = IconLoader.Load(komaData.IconAssetName);
        Move(initData.InitPosition.x, initData.InitPosition.y);
    }

    public void Move(int x, int y)
    {
        var position = UIBoardGridManager.GetPosition(x, y);
        transform.position = position;
    }

    public class Data
    {
        public KomaType Type;
        public Vector2Int InitPosition;
    }

    public class Factory : PlaceholderFactory<Koma.Data, Koma> , IKomaFactory
    {
        
    }
}
