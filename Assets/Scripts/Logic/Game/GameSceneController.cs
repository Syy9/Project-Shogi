using System.Collections;
using System.Collections.Generic;
using MasterData;
using UnityEngine;
using Zenject;

public class GameSceneController : MonoBehaviour
{
    [Inject] GameStateManager gameStateManager;
	void Start ()
    {
        gameStateManager.DispachInitState();
	}
}
