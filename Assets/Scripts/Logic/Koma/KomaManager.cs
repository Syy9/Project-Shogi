using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KomaManager
{
    List<Koma> komaList = new List<Koma>();

    public void Add(Koma koma)
    {
        komaList.Add(koma);
    }

    public Koma Find(Vector2Int position)
    {
        return komaList.FirstOrDefault(koma => koma.Position == position);
    }

    public bool IsEmpty(Vector2Int position)
    {
        return !IsNotEmpty(position);
    }

    public bool IsNotEmpty(Vector2Int position)
    {
        return komaList.Any(koma => koma.Position == position);
    }
}
