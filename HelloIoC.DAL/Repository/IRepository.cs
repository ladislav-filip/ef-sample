using HelloIoC.DAL.DTO;

namespace HelloIoC.DAL.Repository
{
    public interface IRepository<TDTO>
    {
        TDTO GetById(int id);
        void Delete(int id);
    }
}