using UnityEngine;

public class KomaIconLoader
{
    private static readonly string KOMA_PATH = "Koma/";
    public Sprite Load(string fileName)
    {
        return Resources.Load<Sprite>(KOMA_PATH + fileName);
    }

    public Sprite Load(Koma.KomaType type)
    {
        string fileName = null;
        switch (type)
        {
            case Koma.KomaType.Type001:
                fileName = "sgl01";
                break;
            case Koma.KomaType.Type002:
                fileName = "sgl02";
                break;
            default:
                Debug.LogError($"【KomaIconLoader】未実装です。type={type}");
                break;
        }
        return Load(fileName);
    }
}
