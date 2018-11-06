using System.Linq;
using System.Collections.Generic;

namespace MasterData
{
    public interface IKomaDataProvider
    {
        IEnumerable<KomaData> Data { get; }
        KomaData Find(KomaType type, int lv = 1);
        int GetMaxLv(KomaType type);
    }

    public class KomaDataProvider : IDataCreater<KomaData> , IKomaDataProvider
    {
        public IEnumerable<KomaData> Data { get; private set; }

        public KomaDataProvider()
        {
            Data = Create();
        }

        public IEnumerable<KomaData> Create()
        {
            var data = new List<KomaData>();
            data.Add(new KomaData() { KomaType = KomaType.None, Name = "なし", Lv = 1, IconAssetName1 = "none", IconAssetName2 = "none" }); //なし
            data.Add(new KomaData() { KomaType = KomaType.Type001, Name = "王", Lv = 1, IconAssetName1 = "sgl01", IconAssetName2 = "sgl31" }); //王

            data.Add(new KomaData() { KomaType = KomaType.Type002, Name = "飛車", Lv = 1, IconAssetName1 = "sgl02", IconAssetName2 = "sgl32" }); //飛車
            data.Add(new KomaData() { KomaType = KomaType.Type002, Name = "飛車成", Lv = 2, IconAssetName1 = "sgl22", IconAssetName2 = "sgl52" }); //飛車成

            data.Add(new KomaData() { KomaType = KomaType.Type003, Name = "角", Lv = 1, IconAssetName1 = "sgl03", IconAssetName2 = "sgl33" }); //角
            data.Add(new KomaData() { KomaType = KomaType.Type003, Name = "角成", Lv = 2, IconAssetName1 = "sgl23", IconAssetName2 = "sgl53" }); //角成

            data.Add(new KomaData() { KomaType = KomaType.Type004, Name = "金", Lv = 1, IconAssetName1 = "sgl04", IconAssetName2 = "sgl34" }); //金

            data.Add(new KomaData() { KomaType = KomaType.Type005, Name = "銀", Lv = 1, IconAssetName1 = "sgl05", IconAssetName2 = "sgl35" }); //銀
            data.Add(new KomaData() { KomaType = KomaType.Type005, Name = "銀成", Lv = 2, IconAssetName1 = "sgl25", IconAssetName2 = "sgl55" }); //銀成

            data.Add(new KomaData() { KomaType = KomaType.Type006, Name = "桂馬", Lv = 1, IconAssetName1 = "sgl06", IconAssetName2 = "sgl36" }); //桂馬
            data.Add(new KomaData() { KomaType = KomaType.Type006, Name = "桂馬成", Lv = 2, IconAssetName1 = "sgl26", IconAssetName2 = "sgl56" }); //桂馬成

            data.Add(new KomaData() { KomaType = KomaType.Type007, Name = "香車", Lv = 1, IconAssetName1 = "sgl07", IconAssetName2 = "sgl37" }); //香車
            data.Add(new KomaData() { KomaType = KomaType.Type007, Name = "香車成", Lv = 2, IconAssetName1 = "sgl27", IconAssetName2 = "sgl57" }); //香車成

            data.Add(new KomaData() { KomaType = KomaType.Type008, Name = "歩兵", Lv = 1, IconAssetName1 = "sgl08", IconAssetName2 = "sgl38" }); //歩兵
            data.Add(new KomaData() { KomaType = KomaType.Type008, Name = "歩兵成", Lv = 2, IconAssetName1 = "sgl28", IconAssetName2 = "sgl58" }); //歩兵成

            return data;
        }

        public KomaData Find(KomaType type, int lv = 1)
        {
            return Data.First(data => data.KomaType == type && data.Lv == lv);
        }

        public int GetMaxLv(KomaType type)
        {
            return Data.Count(data => data.KomaType == type);
        }
    }
}
