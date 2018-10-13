using System.Collections.Generic;
using System.Linq;
namespace MasterData
{
    public interface IKomaDataProvider
    {
        IEnumerable<KomaData> Data { get; }
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
            data.Add(new KomaData() { KomaType = KomaType.Type001, Lv = 1, IconAssetName = "sgl01" });
            data.Add(new KomaData() { KomaType = KomaType.Type002, Lv = 1, IconAssetName = "sgl02" });
            data.Add(new KomaData() { KomaType = KomaType.Type003, Lv = 1, IconAssetName = "sgl03" });
            data.Add(new KomaData() { KomaType = KomaType.Type004, Lv = 1, IconAssetName = "sgl04" });
            data.Add(new KomaData() { KomaType = KomaType.Type005, Lv = 1, IconAssetName = "sgl05" });
            return data;
        }
    }
}
