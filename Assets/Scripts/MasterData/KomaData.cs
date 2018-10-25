namespace MasterData
{
    public class KomaData
    {
        public KomaType KomaType;
        public string Name;
        public int Lv;
        public string IconAssetName1;
        public string IconAssetName2;
    }

    public static class KomaDataExtension
    {
        public static string GetIconAssetName(this KomaData self, PlayerType type)
        {
            if(self == null)
                return string.Empty;

            switch (type)
            {
                case PlayerType.None:
                case PlayerType.Player1:
                    return self.IconAssetName1;
                case PlayerType.Player2:
                    return self.IconAssetName2;
            }

            return string.Empty;
        }
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
