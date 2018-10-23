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

        public RectTransform Player1Slot;
        public RectTransform Player2Slot;
    }
}
