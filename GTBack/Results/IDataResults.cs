using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Results
{
    public interface IDataResults<T>: IResult
    {
        T Data { get; }
    }
}
