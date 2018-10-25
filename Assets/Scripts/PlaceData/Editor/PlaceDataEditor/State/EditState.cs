using System.Collections;
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
        int selectKomaTypeIndex;
        PlayerType playerType;
        int selectPlayerTypeIndex;
        protected override void OnEnter()
        {
            Owner.Context.Controller = GameObject.FindObjectOfType<PlaceDataEditController>();
            if(Owner.Context.Controller != null)
            {
                Owner.Context.Controller.UIBoard.OnSelect = OnSelect;
            }
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

            var komaTypeArray = Enum.GetValues(typeof(KomaType));
            var komaTypeNames = komaTypeArray.Cast<KomaType>().Select(type => Owner.Context.Controller.FixedDataManager.KomaDataProvider.Find(type).Name).ToArray();
            var komaTypeIntArray = komaTypeArray.Cast<int>().ToArray();
            selectKomaTypeIndex = EditorGUILayout.IntPopup("駒タイプ", selectKomaTypeIndex, komaTypeNames, komaTypeIntArray);
            komaType = (KomaType) selectKomaTypeIndex;

            var playerTypeArray = Enum.GetValues(typeof(PlayerType));
            var playerTypeNames = komaTypeArray.Cast<PlayerType>().Select(type => type.ToString()).ToArray();
            var playerTypeIntArray = komaTypeArray.Cast<int>().ToArray();
            selectPlayerTypeIndex = EditorGUILayout.IntPopup("プレイヤータイプ", selectPlayerTypeIndex, playerTypeNames, playerTypeIntArray);
            playerType = (PlayerType) selectPlayerTypeIndex;
        }

        void OnSelect(Vector2Int position)
        {
            if(komaType == KomaType.None)
                return;

            var koma = komaList.FirstOrDefault(k => k.Position == position);
            var initData = new Koma.InitData();
            if(koma == null)
            {
                initData.Type = komaType;
                initData.Lv = 1;
                initData.InitPosition = position;
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
                data.placeList.Add(place);
            }
        }

        void SetupSlot(PlayerType type)
        {
            var slot = Owner.Context.Controller.GetSlot(type);
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
