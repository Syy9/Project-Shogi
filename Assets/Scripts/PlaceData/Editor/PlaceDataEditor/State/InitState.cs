using System.Collections;
using System.Collections.Generic;
using StateMachine;
using UnityEditor;
using UnityEngine;
namespace PlaceData.Edit
{
    public class InitState : State<PlaceDataEditor>
    {
        protected override void OnEnter()
        {
            EditorApplication.delayCall += () =>
            {
                Owner.ChangeState<WaitReadyState>();
            };
        }
    }

}
