using System.Collections.Generic;

namespace MasterData
{
    public interface IDataCreater<T>
    {
        IEnumerable<T> Create();
    }
}
