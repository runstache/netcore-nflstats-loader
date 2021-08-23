using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NflStats.Loader.Transformers
{
    public interface ITransformer<T, U>
    {
        U Transform(T item);
    }
}
