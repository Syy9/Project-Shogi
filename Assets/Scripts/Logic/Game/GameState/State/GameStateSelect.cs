using System.Collections;
using StateMachine;
using UnityEngine;

public class GameStateSelect : GameStateBase
{
    protected override void OnEnter()
    {
        Owner.CoroutineService.Start(Hoge());
    }

    IEnumerator Hoge()
    {
        foreach (var komaData in Owner.FixedDataManager.KomaDataProvider.Data)
        {
            yield return new WaitForSeconds(1);
            var initData = new Koma.InitData();
            initData.Type = komaData.KomaType;
            initData.InitPosition = new Vector2Int(0, 0);
            Owner.KomaFactory.Create(initData);
        }
    }
}
