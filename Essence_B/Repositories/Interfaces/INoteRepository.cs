//using Essence_B.Models.DB;
using Essence_B.Models.Domain.notes;
using Essence_B.Models.Domain.Perfums;
using Essence_B.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace Essence_B.Repositories.Interfaces
{
    public interface INoteRepository
    {
        List<NoteTypeDto> getNoteTypes();
        List<NoteDto> getNotes();
        List<HousesDto> getHouses();
        List<GenderDto> getGenders();
        List<SizeDto> getSizes();
        List<ConcentrationDto> getConcentrations();
    }
}
