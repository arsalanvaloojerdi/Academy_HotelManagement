using System.Threading.Tasks;

namespace HotelManagement.Infrastructure.Persistence
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}