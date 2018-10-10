using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameSceneController : MonoBehaviour
{
    [Inject] IKomaFactory komaFactory;
	IEnumerator Start () {
		for (int i = 0; i < 9; i++)
        {
            yield return new WaitForSeconds(1);
            Koma.Data dummy = new Koma.Data();
            dummy.InitPosition = new Vector2Int(i,0);
            dummy.Type = Koma.KomaType.Type002;
            komaFactory.Create(dummy);
        }
	}
}
