using System.Collections;
using Zenject;

public class GameStateinit : GameStateBase
{
    protected override void OnEnter()
    {
        foreach (var place in Owner.PlaceData.placeList)
        {
            var initData = new Koma.InitData(place);
            Owner.KomaFactory.Create(initData);
        }

        Owner.ChangeState<GameStateSelect>();
    }
}
