using System.Threading.Tasks;

namespace HotelManagement.Infrastructure.Persistence
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public EFUnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}