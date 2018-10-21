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
            data.Add(new KomaData() { KomaType = KomaType.None, Name = "なし", Lv = 1, IconAssetName = "none" }); //なし
            data.Add(new KomaData() { KomaType = KomaType.Type001, Name = "王", Lv = 1, IconAssetName = "sgl01" }); //王

            data.Add(new KomaData() { KomaType = KomaType.Type002, Name = "飛車", Lv = 1, IconAssetName = "sgl02" }); //飛車
            data.Add(new KomaData() { KomaType = KomaType.Type002, Name = "飛車成", Lv = 2, IconAssetName = "sgl22" }); //飛車成

            data.Add(new KomaData() { KomaType = KomaType.Type003, Name = "角", Lv = 1, IconAssetName = "sgl03" }); //角
            data.Add(new KomaData() { KomaType = KomaType.Type003, Name = "角成", Lv = 2, IconAssetName = "sgl23" }); //角成

            data.Add(new KomaData() { KomaType = KomaType.Type004, Name = "金", Lv = 1, IconAssetName = "sgl04" }); //金

            data.Add(new KomaData() { KomaType = KomaType.Type005, Name = "銀", Lv = 1, IconAssetName = "sgl05" }); //銀
            data.Add(new KomaData() { KomaType = KomaType.Type005, Name = "銀成", Lv = 2, IconAssetName = "sgl25" }); //銀成

            data.Add(new KomaData() { KomaType = KomaType.Type006, Name = "桂馬", Lv = 1, IconAssetName = "sgl06" }); //桂馬
            data.Add(new KomaData() { KomaType = KomaType.Type006, Name = "桂馬成", Lv = 2, IconAssetName = "sgl26" }); //桂馬成

            data.Add(new KomaData() { KomaType = KomaType.Type007, Name = "香車", Lv = 1, IconAssetName = "sgl07" }); //香車
            data.Add(new KomaData() { KomaType = KomaType.Type007, Name = "香車成", Lv = 2, IconAssetName = "sgl27" }); //香車成

            data.Add(new KomaData() { KomaType = KomaType.Type008, Name = "歩兵", Lv = 1, IconAssetName = "sgl08" }); //歩兵
            data.Add(new KomaData() { KomaType = KomaType.Type008, Name = "歩兵成", Lv = 2, IconAssetName = "sgl28" }); //歩兵成

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
