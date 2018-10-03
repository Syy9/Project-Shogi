using UnityEngine;

public class KomaIconLoader
{
    private static readonly string KOMA_PATH = "Koma/";
    public Sprite Load(string fileName)
    {
        return Resources.Load<Sprite>(KOMA_PATH + fileName);
    }
}
