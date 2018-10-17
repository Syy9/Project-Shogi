using System.Linq;
using System.Collections.Generic;

namespace MasterData
{
    public interface IKomaDataProvider
    {
        IEnumerable<KomaData> Data { get; }
        KomaData Find(KomaType type);
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
            data.Add(new KomaData() { KomaType = KomaType.Type001, Lv = 1, IconAssetName = "sgl01" }); //王

            data.Add(new KomaData() { KomaType = KomaType.Type002, Lv = 1, IconAssetName = "sgl02" }); //飛車
            data.Add(new KomaData() { KomaType = KomaType.Type002, Lv = 2, IconAssetName = "sgl22" }); //飛車成

            data.Add(new KomaData() { KomaType = KomaType.Type003, Lv = 1, IconAssetName = "sgl03" }); //角
            data.Add(new KomaData() { KomaType = KomaType.Type003, Lv = 2, IconAssetName = "sgl23" }); //角成

            data.Add(new KomaData() { KomaType = KomaType.Type004, Lv = 1, IconAssetName = "sgl04" }); //金

            data.Add(new KomaData() { KomaType = KomaType.Type005, Lv = 1, IconAssetName = "sgl05" }); //銀
            data.Add(new KomaData() { KomaType = KomaType.Type005, Lv = 2, IconAssetName = "sgl25" }); //銀成

            data.Add(new KomaData() { KomaType = KomaType.Type006, Lv = 1, IconAssetName = "sgl06" }); //桂馬
            data.Add(new KomaData() { KomaType = KomaType.Type006, Lv = 2, IconAssetName = "sgl26" }); //桂馬成

            data.Add(new KomaData() { KomaType = KomaType.Type007, Lv = 1, IconAssetName = "sgl07" }); //香車
            data.Add(new KomaData() { KomaType = KomaType.Type007, Lv = 2, IconAssetName = "sgl27" }); //香車成

            data.Add(new KomaData() { KomaType = KomaType.Type008, Lv = 1, IconAssetName = "sgl08" }); //歩兵
            data.Add(new KomaData() { KomaType = KomaType.Type008, Lv = 2, IconAssetName = "sgl28" }); //歩兵成

            return data;
        }

        public KomaData Find(KomaType type)
        {
            return Data.First(data => data.KomaType == type);
        }
    }
}
