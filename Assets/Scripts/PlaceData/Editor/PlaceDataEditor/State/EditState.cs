﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using UnityEditor;
using MasterData;
using System.Linq;
using System;

namespace PlaceData.Edit
{
    public class EditState : State<PlaceDataEditor>
    {
        List<Koma> komaList = new List<Koma>();
        KomaType komaType;
        PlayerType playerType;
        protected override void OnEnter()
        {
            Owner.Context.Controller = GameObject.FindObjectOfType<PlaceDataEditController>();
            if(Owner.Context.Controller == null)
            {
                throw new Exception("Cannot find PlaceDataEditController");
            }

            Owner.Context.Controller.UIBoard.OnSelect = OnSelect;
            SetupSlot(PlayerType.Player1);
            SetupSlot(PlayerType.Player2);
            Owner.Repaint();
        }

        protected override void OnUpdate()
        {
            if (!Owner.CanEdit())
            {
                EditorApplication.delayCall += () => {
                    Owner.ChangeState<WaitReadyState>();
                };
                return;
            }
            EditorGUILayout.LabelField("編集中");
            Owner.Context.Edit = (PlaceData) EditorGUILayout.ObjectField("PlaceData", Owner.Context.Edit, typeof(PlaceData), false);
            if(GUILayout.Button("配置"))
            {
                Place(Owner.Context.Edit);
            }
            if(GUILayout.Button("リセット"))
            {
                Reset();
            }
            if(GUILayout.Button("保存"))
            {
                Save(komaList, Owner.Context.Edit);
            }

            var komaTypeNames = Enum.GetValues(typeof(KomaType)).Cast<KomaType>().Select(type => Owner.Context.Controller.FixedDataManager.KomaDataProvider.Find(type).Name).ToArray();
            komaType = (KomaType) EditorGUILayout.Popup("駒Type", (int) komaType, komaTypeNames);

            playerType = (PlayerType)EditorGUILayout.EnumPopup("プレイヤータイプ", playerType);
        }

        void OnSelect(Vector2Int position)
        {
            if(komaType == KomaType.None || playerType == PlayerType.None)
                return;

            var koma = komaList.FirstOrDefault(k => k.Position == position);
            var initData = new Koma.InitData();
            if(koma == null)
            {
                initData.Type = komaType;
                initData.Lv = 1;
                initData.InitPosition = position;
                initData.PlayerType = playerType;
                var newKoma = Owner.Context.Controller.KomaFactory.Create(initData);
                komaList.Add(newKoma);
            } else {
                if(Owner.Context.Controller.FixedDataManager.KomaDataProvider.GetMaxLv(koma.Type) == koma.Lv)
                {
                    komaList.Remove(koma);
                    GameObject.Destroy(koma.gameObject);
                } else {
                    initData.Type = koma.Type;
                    initData.Lv = koma.Lv + 1;
                    initData.InitPosition = koma.Position;
                    initData.PlayerType = koma.PlayerType;
                    koma.Init(initData);
                }
            }
        }

        void Reset()
        {
            foreach (var koma in komaList)
            {
                GameObject.Destroy(koma);
            }
            komaList.Clear();
        }

        void Place(PlaceData data)
        {
            foreach (var place in data.placeList)
            {
                var initData = new Koma.InitData();
                initData.Type = place.KomaType;
                initData.Lv = place.Lv;
                initData.InitPosition = place.Position;
                initData.PlayerType = place.PlayerType;
                var newKoma = Owner.Context.Controller.KomaFactory.Create(initData);
                komaList.Add(newKoma);
            }
        }

        void Save(List<Koma> komaList, PlaceData data)
        {
            Undo.RegisterCompleteObjectUndo(data, "PlaceData - Save");
            data.placeList.Clear();
            foreach (var koma in komaList)
            {
                var place = new Place();
                place.KomaType = koma.Type;
                place.Lv = koma.Lv;
                place.Position = koma.Position;
                place.PlayerType = koma.PlayerType;
                data.placeList.Add(place);
            }
        }

        void SetupSlot(PlayerType playerType)
        {
            var slot = Owner.Context.Controller.GetSlot(playerType);
            while(slot.childCount >= 1)
            {
                GameObject.Destroy(slot.GetChild(0).gameObject);
            }

            var komaTypeArray = Enum.GetValues(typeof(KomaType)).Cast<KomaType>();
            foreach (var komaType in komaTypeArray)
            {
                if(komaType == KomaType.None)
                    continue;
                var initData = new Koma.InitData();
                initData.Type = komaType;
                initData.Lv = 1;
                initData.PlayerType = playerType;
                var newKoma = Owner.Context.Controller.KomaFactory.Create(initData);
                newKoma.transform.SetParent(slot);
            }
        }
    }
}
