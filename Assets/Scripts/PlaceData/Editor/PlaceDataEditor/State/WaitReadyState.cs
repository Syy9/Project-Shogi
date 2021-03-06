﻿using System.Collections;
using System.Collections.Generic;
using StateMachine;
using UnityEditor;
using UnityEngine;
namespace PlaceData.Edit
{
    public class WaitReadyState : State<PlaceDataEditor>
    {
        protected override void OnEnter()
        {
            Owner.Repaint();
        }

        protected override void OnUpdate()
        {
            EditorGUILayout.LabelField("Setup...play scene and set PlaceData");
            EditContext.instance.Edit = EditorGUILayout.ObjectField("PlaceData", EditContext.instance.Edit, typeof(PlaceData), false) as PlaceData;
            if (PlaceDataEditor.IsEditScene())
            {
                if (!EditorApplication.isPlaying)
                {
                    if (GUILayout.Button("Play EditScene"))
                    {
                        EditorApplication.isPlaying = true;
                    }
                }
            }
            else
            {
                if (GUILayout.Button("Open EditScene"))
                {
                    PlaceDataEditor.OpenEditScene();
                }
            }

            if (Owner.CanEdit())
            {
                EditorApplication.delayCall += () =>
                {
                    Owner.ChangeState<EditState>();
                };
            }
        }
    }


}
