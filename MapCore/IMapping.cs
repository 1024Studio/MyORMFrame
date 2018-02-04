using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
    public interface IMapping<Tkey, TValue>
    {
        KeyValuePair<Tkey, TValue> Mapping { get; }
    }
}
