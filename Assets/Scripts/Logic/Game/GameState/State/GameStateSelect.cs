using StateMachine;
using UnityEngine;

public class GameStateSelect : GameStateBase
{
    protected override void OnEnter()
    {
        Debug.Log("OnEnter : " + Owner.GetType());
    }
}
