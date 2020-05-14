using HRHub_API.Contracts;
using HRHub_API.Data;
using HRHub_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRHub_API.Services
{
    public class reg_eu_SectorRepository : Ireg_eu_SectorRepository
    {
        private readonly ApplicationDbContext _db;

        public reg_eu_SectorRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(reg_eu_Sector entity)
        {
            await _db.reg_eu_Sector.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(reg_eu_Sector entity)
        {
            _db.reg_eu_Sector.Remove(entity);
            return await Save();
        }

        public async Task<IList<reg_eu_Sector>> FindAll()
        {
            var reg_eu_Sector = await _db.reg_eu_Sector.ToListAsync();
            return reg_eu_Sector;
        }

        public async Task<reg_eu_Sector> FindbyId(int id)
        {
            var reg_eu_Sector = await _db.reg_eu_Sector.FindAsync(id);
            return reg_eu_Sector;
        }

        public async Task<bool> isExists(int id)
        {
           var exists = await _db.reg_eu_Sector.AnyAsync(a=> a.reg_eu_SectorId == id);

            return exists;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
           
            return changes >0;

        }

        public async Task<bool> Update(reg_eu_Sector entity)
        {
            _db.reg_eu_Sector.Update(entity);
            return await Save();
        }
    }
}
