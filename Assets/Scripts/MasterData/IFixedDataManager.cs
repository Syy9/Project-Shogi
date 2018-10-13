using System.Collections.Generic;

namespace MasterData
{
    public interface IFixedDataManager
    {
        IKomaDataProvider KomaDataProvider { get; }
    }
}
