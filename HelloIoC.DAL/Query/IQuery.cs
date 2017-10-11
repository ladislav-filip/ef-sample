using System.Collections;
using System.Collections.Generic;

namespace HelloIoC.DAL.Query
{
    public interface IQuery<TDTO>
    {
        int PageSize { get; }

        int PageIndex { get; }
        
        IList<TDTO> Execute();
    }
}