using HelloIoC.DAL.DTO;

namespace HelloIoC.DAL.Repository
{
    public interface IRepository
    {
        ContactDTO GetById(int id);
    }
}