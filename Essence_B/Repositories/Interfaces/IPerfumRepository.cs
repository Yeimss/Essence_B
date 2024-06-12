using Essence_B.Models.DB;
using Essence_B.Models.Domain.Perfums;

namespace Essence_B.Repositories.Interfaces
{
    public interface IPerfumRepository
    {
        Task<bool> InsertPerfum(PerfumDto perfum);
        object? searchPerfum(PerfumDto perfum);
        List<object> getActivePerfums();
        List<object> getAllPerfums();
    }
}
