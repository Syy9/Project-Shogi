using System.Collections;
using MasterData;
using StateMachine;
using UnityEngine;

public class GameStateSelect : GameStateBase
{
    protected override void OnEnter()
    {
        Owner.UIBoard.OnSelect += OnSelect;
    }

    protected override void OnExit()
    {
        Owner.UIBoard.OnSelect -= OnSelect;
    }

    void OnSelect(Vector2Int position)
    {
        var initData = new Koma.InitData();
        initData.Type = KomaType.Type001;
        initData.InitPosition = position;
        Owner.KomaFactory.Create(initData);
    }
}
