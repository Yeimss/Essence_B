﻿using Essence_B.Models.DB;
using Essence_B.Models.Domain.Perfums;
using Essence_B.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Essence_B.Repositories.Implementation
{
    public class PerfumRepository : IPerfumRepository
    {
        private readonly EssenceContext dbContext;
        public PerfumRepository(EssenceContext _dbContext) {
            dbContext = _dbContext;
        }
        public async Task<bool> InsertPerfum(PerfumDto perfum)
        {
            try
            {
                Tbperfum tbperfum = new Tbperfum();
                tbperfum.Name = perfum.Name;
                tbperfum.IdHouse = perfum.IdHouse;
                tbperfum.IdHouseNavigation = dbContext.Tbhouses.FirstOrDefault(e=> e.IdHouse == perfum.IdHouse);
                tbperfum.IdGender = perfum.IdGender;
                tbperfum.IdGenderNavigation = dbContext.Tbgenders.FirstOrDefault(e => e.IdGender ==  perfum.IdGender);
                tbperfum.IdOrigin = perfum.IdOrigin;
                tbperfum.IdOriginNavigation = dbContext.Tborigins.FirstOrDefault(e => e.IdOrigin == perfum.IdOrigin);
                tbperfum.Status = perfum.Status;
                tbperfum.Photo = perfum.Photo;
                tbperfum.Description = perfum.Description;
                tbperfum.IdConcentration = perfum.IdConcentration;
                tbperfum.IdConcentrationNavigation = dbContext.Tbconcentrations.FirstOrDefault(e => e.IdConcentration == perfum.IdConcentration);

                var res = await dbContext.Tbperfums.AddAsync(tbperfum);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int? searchIdPerfum(PerfumDto perfum)
        {
            Tbperfum? perfume = new Tbperfum();
            perfume = dbContext.Tbperfums.FirstOrDefault(e => e.IdHouse == perfum.IdHouse && e.Name == perfum.Name && e.IdOrigin == perfum.IdOrigin && e.IdConcentration == perfum.IdConcentration);
            return perfume?.IdPerfum;
        }
        public List<object> getActivePerfums()
        {
            List<object> list = new List<object>();
            var perfums = dbContext.Tbperfums.Where(per => per.Status == true);
            if (perfums.Count() > 0)
            {
                foreach (var item in perfums)
                {
                    PerfumDto perfum = new PerfumDto();
                    perfum.Name = item.Name;
                    perfum.IdHouse = item.IdHouse;
                    perfum.IdGender = item.IdGender;
                    perfum.IdOrigin = item.IdOrigin;
                    perfum.Status = item.Status;
                    perfum.Photo = item.Photo;
                    perfum.Description = item.Description;
                    perfum.IdConcentration = item.IdConcentration;
                    list.Add(perfum);
                }
            }
            return list;
        }
        public List<object> getAllPerfums()
        {
            List<object> list = new List<object>();
            var perfums = dbContext.Tbperfums.ToListAsync();
            if (perfums.Result.Count > 0)
            {
                foreach (var item in perfums.Result)
                {
                    PerfumDto perfum = new PerfumDto();
                    perfum.Name = item.Name;
                    perfum.IdHouse = item.IdHouse;
                    perfum.IdGender = item.IdGender;
                    perfum.IdOrigin = item.IdOrigin;
                    perfum.Status = item.Status;
                    perfum.Photo = item.Photo;
                    perfum.Description = item.Description;
                    perfum.IdConcentration = item.IdConcentration;
                    //perfum.price = item.pri
                    list.Add(perfum);
                }
            }
            return list;
        }
        public async Task<bool> InsertPerfumNote(PerfumNote dto)
        {
            try
            {
                TbperfumNote tbperfum = new TbperfumNote();
                tbperfum.IdPerfum = dto.IdPerfum;
                tbperfum.IdPerfumNavigation = dbContext.Tbperfums.FirstOrDefault(e => e.IdPerfum == dto.IdPerfum);
                tbperfum.IdNote = dto.IdNote;
                tbperfum.IdNoteNavigation = dbContext.Tbnotes.FirstOrDefault(e => e.IdNote == dto.IdNote);
                tbperfum.IdNoteType = dto.IdNoteType;
                tbperfum.IdNoteTypeNavigation = dbContext.TbnoteTypes.FirstOrDefault(e => e.IdNoteType == dto.IdNoteType);
                var res = await dbContext.TbperfumNotes.AddAsync(tbperfum);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
