using Essence_B.Models.Domain.Perfums;

namespace Essence_B.Repositories.Interfaces
{
    public interface IPerfumRepository
    {
        bool InsertPerfum(PerfumDto perfum);
        List<PerfumDto> getActivePerfums();
        List<object> getAllPerfums();

    }
}
