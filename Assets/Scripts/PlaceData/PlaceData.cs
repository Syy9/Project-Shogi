using System;
using System.Collections;
using System.Collections.Generic;
using MasterData;
using UnityEngine;
namespace PlaceData.Edit
{
    [CreateAssetMenu()]
    public class PlaceData : ScriptableObject
    {
        public List<Place> placeList = new List<Place>();
    }

    [Serializable]
    public class Place
    {
        public Vector2Int Position;
        public KomaType KomaType;
        public int Lv = 1;
        public PlayerType PlayerType;

        public Place() { }
        public Place(Koma.InitData data, PlayerType playerType)
        {
            Position = data.InitPosition;
            KomaType = data.Type;
            Lv = data.Lv;
            PlayerType = playerType;
        }
    }

}
