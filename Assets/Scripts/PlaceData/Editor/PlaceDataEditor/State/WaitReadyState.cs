using System.Collections;
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
        }

        protected override void OnUpdate()
        {
            EditorGUILayout.LabelField("準備中...PlaceDataをセットしてシーンを再生");
            Owner.Context.Edit = EditorGUILayout.ObjectField("PlaceData", Owner.Context.Edit, typeof(PlaceData), false) as PlaceData;
            if(PlaceDataEditor.IsEditScene())
            {
                if (!EditorApplication.isPlaying)
                {
                    if (GUILayout.Button("シーンを再生する"))
                    {
                        EditorApplication.isPlaying = true;
                    }
                }
            } else {
                if(GUILayout.Button("編集シーンに移動する"))
                {
                    PlaceDataEditor.OpenEditScene();
                }
            }

            if(Owner.CanEdit())
            {
                Owner.ChangeState<EditState>();
                return;
            }
        }
    }


}
