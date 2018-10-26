using System;
using System.Collections;
using System.Collections.Generic;
using MasterData;
using UnityEngine;
using Zenject;
namespace PlaceData.Edit
{
    public class PlaceDataEditController : MonoBehaviour
    {
        [Inject] public CoroutineService CoroutineService { get; private set; }
        [Inject] public IFixedDataManager FixedDataManager { get; private set; }
        [Inject] public IKomaFactory KomaFactory { get; private set; }
        [Inject] public IUIBoard UIBoard { get; private set; }

        [SerializeField] PlaceDataEditSlotController Player1Slot;
        [SerializeField] PlaceDataEditSlotController Player2Slot;
        public PlaceDataEditSlotController GetSlotController(PlayerType type)
        {
            switch (type)
            {
                case PlayerType.Player1:
                    return Player1Slot;
                case PlayerType.Player2:
                    return Player2Slot;
                default:
                    throw new Exception($"Cannot find slot. type={type}");
            }
        }
    }
}
