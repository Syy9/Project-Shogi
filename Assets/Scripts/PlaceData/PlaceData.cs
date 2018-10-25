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

    public static class PlaceDataExtension
    {
        public static void OverwiteSave(this PlaceData self, List<Koma> komaList)
        {
            self.placeList.Clear();
            foreach (var koma in komaList)
            {
                var place = new Place();
                place.KomaType = koma.Type;
                place.Lv = koma.Lv;
                place.Position = koma.Position;
                place.PlayerType = koma.PlayerType;
                self.placeList.Add(place);
            }
        }
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
