﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using MasterData;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using System;
using StateMachine;
namespace PlaceData.Edit
{
    public class PlaceDataEditor : StateOwner
    {
        const string EditrScenePath = "Assets/Scripts/PlaceData/Editor/PlaceDataEditScene.unity";
        const string EditSceneName = "PlaceDataEditScene";
        public EditContext Context = new EditContext();

        protected override void SetupState()
        {
            Register<InitState>();
            Register<WaitReadyState>();
            Register<EditState>();
        }

        public override void Start()
        {
            ChangeState<InitState>();
        }

        public bool CanEdit()
        {
            return EditorApplication.isPlaying && Context.Edit != null;
        }

        public void OnGUI()
        {
            Update();
        }



        public static void OpenEditSceneIfNeed()
        {
            if (!PlaceDataEditor.IsEditScene())
            {
                if (EditorUtility.DisplayDialog("PlaceDataEdit", "編集シーンを開きますか？", "はい", "いいえ"))
                {
                    OpenEditScene();
                }
            }
        }

        public static void OpenEditScene()
        {
            EditorSceneManager.OpenScene(EditrScenePath);
        }

        public static bool IsEditScene()
        {
            return EditorSceneManager.GetActiveScene().name == EditSceneName;
        }
    }

}