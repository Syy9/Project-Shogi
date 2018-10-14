using System.Collections;
using System.Collections.Generic;
using MasterData;
using UnityEngine;
using Zenject;

public class GameSceneController : MonoBehaviour
{
    [Inject] IFixedDataManager fixedDataManager;
    [Inject] IKomaFactory komaFactory;
	IEnumerator Start () {
        foreach (var komaData in fixedDataManager.KomaDataProvider.Data)
        {
            yield return new WaitForSeconds(1);
            var initData = new Koma.Data();
            initData.Type = komaData.KomaType;
            initData.InitPosition = new Vector2Int(0, 0);
            komaFactory.Create(initData);
        }
	}
}
