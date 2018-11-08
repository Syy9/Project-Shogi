using System.Collections;
using MasterData;
using StateMachine;
using UnityEngine;

public class GameStateSelect : GameStateBase
{
    Vector2Int NoSelectPosition = new Vector2Int(-1, -1);
    Vector2Int _selectPosition;
    protected override void OnEnter()
    {
        _selectPosition = NoSelectPosition;
        Owner.UIBoard.OnSelect += OnSelect;
    }

    protected override void OnExit()
    {
        Owner.UIBoard.OnSelect -= OnSelect;
    }

    void OnSelect(Vector2Int position)
    {
        if (_selectPosition == position)
        {
            Owner.UIBoard.SetHighlight(position, false);
            return;
        }

        if (_selectPosition != NoSelectPosition) //移動先選択中
        {
            if (Owner.KomaManager.IsEmpty(position))
            {
                var koma = Owner.KomaManager.Find(_selectPosition);
                koma.Move(position);
            }
            Owner.UIBoard.SetHighlight(_selectPosition, false);
            _selectPosition = NoSelectPosition;
        }
        else
        {
            if (Owner.KomaManager.IsNotEmpty(position))
            {
                Owner.UIBoard.SetHighlight(position, true);
                _selectPosition = position;
            }
            else
            {
                _selectPosition = NoSelectPosition;
            }
        }
    }
}
