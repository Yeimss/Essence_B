using Essence_B.Models.DB;
using Essence_B.Models.Domain.notes;
using Essence_B.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Essence_B.Repositories.Implementation
{
    public class NoteRepository : INoteRepository
    {
        private readonly EssenceContext dbContext;

        public NoteRepository(EssenceContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<NoteTypeDto> getNoteTypes()
        {
            List<NoteTypeDto> list = new List<NoteTypeDto>();
            var notas = dbContext.TbNoteTypes.ToListAsync();
            if(notas.Result.Count > 0)
            {
                foreach (var item in notas.Result)
                {
                    NoteTypeDto nota = new NoteTypeDto();
                    nota.IdNoteType = item.IdNoteType;
                    nota.NoteType = item.NoteType;
                    list.Add(nota); 
                }
            }
            return list;
        }
        public List<NoteDto> getNotes()
        {
            List<NoteDto> list = new List<NoteDto>();
            var notas = dbContext.TbNotes.ToListAsync();
            if (notas.Result.Count > 0)
            {
                foreach (var item in notas.Result)
                {
                    NoteDto nota = new NoteDto();
                    nota.IdNote = item.IdNote;
                    nota.Note = item.Note;
                    list.Add(nota);
                }
            }
            return list;
        }
        public List<HousesDto> getHouses()
        {
            List<HousesDto> list = new List<HousesDto>();
            var notas = dbContext.TbHouses.ToListAsync();
            if (notas.Result.Count > 0)
            {
                foreach (var item in notas.Result)
                {
                    HousesDto casa = new HousesDto();
                    casa.IdHouse = item.IdHouse;
                    casa.House = item.House;
                    casa.IdOrigin = item.IdOrigin;
                    list.Add(casa);
                }
            }
            return list;
        }
    }
}
