namespace HelloIoC.DAL.Query
{
    interface IFilterQuery<TFilter, TDTO> : IQuery<TDTO>
    {
        TFilter Filter { get; }
    }
}