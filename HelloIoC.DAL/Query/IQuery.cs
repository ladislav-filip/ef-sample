using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HelloIoC.DAL.Query
{
    public interface IFirstLevelQuery<out TEntity>
    {
        IQueryable<TEntity> GetSource();
    }
    
    public interface IQuery<TDTO>
    {
        int PageSize { get; }

        int PageIndex { get; }
        
        IList<TDTO> Execute();
    }

    interface IFilterQuery<TFilter, TDTO, TEntity> : IQuery<TDTO>
    {
        TFilter Filter { get; }
    }
}