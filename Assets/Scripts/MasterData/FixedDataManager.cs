using System;
using System.Collections.Generic;

namespace MasterData
{
    public class FixedDataManager : IFixedDataManager
    {
        public FixedDataManager()
        {
            KomaDatas = new List<KomaData>();
            KomaDatas.Add(new KomaData() { KomaType = KomaType.Type001, IconAssetName = "sgl01" });
            KomaDatas.Add(new KomaData() { KomaType = KomaType.Type002, IconAssetName = "sgl02" });
            KomaDatas.Add(new KomaData() { KomaType = KomaType.Type003, IconAssetName = "sgl03" });
            KomaDatas.Add(new KomaData() { KomaType = KomaType.Type004, IconAssetName = "sgl04" });
            KomaDatas.Add(new KomaData() { KomaType = KomaType.Type005, IconAssetName = "sgl05" });

        }

        public List<KomaData> KomaDatas { get; private set; }
    }


}
