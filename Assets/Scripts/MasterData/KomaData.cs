namespace MasterData
{
    public class KomaData
    {
        public KomaType KomaType;
        public string IconAssetName;
    }

    public enum KomaType
    {
        None,
        Type001, //王
        Type002, //飛車
        Type003, //角
        Type004,
        Type005,
    }
}
