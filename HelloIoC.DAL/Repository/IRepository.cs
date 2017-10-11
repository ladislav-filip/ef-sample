using HelloIoC.DAL.DTO;

namespace HelloIoC.DAL.Repository
{
    public interface IContactRepository
    {
        ContactDTO GetById(int id);
    }
}