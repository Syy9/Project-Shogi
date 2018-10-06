using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameSceneController : MonoBehaviour
{
    [Inject] IKomaGenerator komaGenerator;
	IEnumerator Start () {
		for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1);
            komaGenerator.Create();
        }
	}
}
