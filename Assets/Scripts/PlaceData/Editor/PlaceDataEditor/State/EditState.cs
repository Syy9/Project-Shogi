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
        protected override void OnEnter()
        {
            Owner.Context.Controller = GameObject.FindObjectOfType<PlaceDataEditController>();
            if(Owner.Context.Controller != null)
            {
                Owner.Context.Controller.UIBoard.OnSelect = OnSelect;
            }
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
        }

        void OnSelect(Vector2Int position)
        {
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
    }
}
