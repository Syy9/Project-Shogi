using System;
using System.Collections.Generic;

namespace MasterData
{
    public class FixedDataManager : IFixedDataManager
    {
        public FixedDataManager()
        {
            KomaDataProvider = new KomaDataProvider();
        }

        public IKomaDataProvider KomaDataProvider { get; private set; }
    }


}
