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
            EditorGUILayout.LabelField("Editing");
            Owner.Context.Edit = (PlaceData) EditorGUILayout.ObjectField("PlaceData", Owner.Context.Edit, typeof(PlaceData), false);
            if(GUILayout.Button("Replace"))
            {
                Place(Owner.Context.Edit);
            }
            if(GUILayout.Button("Clear"))
            {
                var message = "You cannot undo this action";
                if(EditorUtility.DisplayDialog("Clear place data?",  message, "Clear", "Cancel"))
                {
                    Clear();
                }
            }
            if(GUILayout.Button("Save"))
            {
                Save(Owner.Context.Edit, komaList);
            }
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

        void Clear()
        {
            foreach (var koma in komaList)
            {
                GameObject.Destroy(koma.gameObject);
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

        void Save(PlaceData data, List<Koma> komaList)
        {
            Undo.RegisterCompleteObjectUndo(data, "PlaceData - Save");
            data.OverwiteSave(komaList);
            EditorUtility.SetDirty(data);
            AssetDatabase.SaveAssets();
        }

        void SetupSlot(PlayerType playerType)
        {
            var slotController = Owner.Context.Controller.GetSlotController(playerType);
            slotController.RemoveAll();

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
                slotController.Add(newKoma);
            }

            slotController.OnSelect = (koma) => {
                var otherSlotContrller = Owner.Context.Controller.GetOtherSlotController(playerType);
                otherSlotContrller.ResetSelect();
                this.komaType = koma.Type;
                this.playerType = koma.PlayerType;
            };
        }
    }
}
