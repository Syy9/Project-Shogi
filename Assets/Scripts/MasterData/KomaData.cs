namespace MasterData
{
    public class KomaData
    {
        public KomaType KomaType;
        public int Lv;
        public string IconAssetName;
    }

    public enum KomaType
    {
        None,
        Type001, //王
        Type002, //飛車
        Type003, //角
        Type004, //金
        Type005, //銀
        Type006, //桂馬
        Type007, //香車
        Type008, //歩兵
    }
}
