using System.Collections;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;
namespace PlaceData.Edit
{
    public class InitState : State<PlaceDataEditor>
    {
        protected override void OnEnter()
        {
            Owner.ChangeState<WaitReadyState>();
        }
    }

}
