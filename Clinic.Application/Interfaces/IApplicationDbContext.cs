using Clinic.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Clinic.Application.Interfaces
{
    public interface IApplicationDbContext 
    {
        DbSet<Record> Records { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
