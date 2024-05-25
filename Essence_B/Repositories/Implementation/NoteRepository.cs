using Essence_B.Models.DB;
using Essence_B.Models.Domain.notes;
using Essence_B.Models.Domain.Perfums;
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
            var notas = dbContext.TbnoteTypes.ToListAsync();
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
            var notas = dbContext.Tbnotes.ToListAsync();
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
            var notas = dbContext.Tbhouses.ToListAsync();
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

        public List<GenderDto> getGenders()
        {
            List<GenderDto> list = new List<GenderDto>();
            var notas = dbContext.Tbgenders.ToListAsync();
            if (notas.Result.Count > 0)
            {
                foreach (var item in notas.Result)
                {
                    GenderDto genero = new GenderDto();
                    genero.IdGender = item.IdGender;
                    genero.Gender = item.Gender;
                    list.Add(genero);
                }
            }
            return list;
        }
        public List<ConcentrationDto> getConcentrations()
        {
            List<ConcentrationDto> list = new List<ConcentrationDto>();
            var notas = dbContext.Tbconcentrations.ToListAsync();
            if (notas.Result.Count > 0)
            {
                foreach (var item in notas.Result)
                {
                    ConcentrationDto concentration = new ConcentrationDto();
                    concentration.IdConcentration = item.IdConcentration;
                    concentration.Concentration = item.Concentration;
                    list.Add(concentration);
                }
            }
            return list;
        }
        public List<SizeDto> getSizes()
        {
            List<SizeDto> list = new List<SizeDto>();
            var notas = dbContext.Tbsizes.ToListAsync();
            if (notas.Result.Count > 0)
            {
                foreach (var item in notas.Result)
                {
                    SizeDto size = new SizeDto();
                    size.IdSize = item.IdSize;
                    size.Size = item.Size;
                    list.Add(size);
                }
            }
            return list;
        }
    }
}
