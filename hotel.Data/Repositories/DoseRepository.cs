using Restaurant.Core.Repositories;
using Restaurant.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Core.Restaurant;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Data.Repositories
{
    public class DoseRepository: IDoseRepository
    {
        private readonly DataContext _context;
        public DoseRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Dose> AddDoseAsync(Dose Dose) 
        {
            _context.Doses.Add(Dose);
            await _context.SaveChangesAsync();
            return Dose;
        }
        public async Task DeleteDoseAsync(int id)
        {
            var temp = await GetDoseByIdAsync(id);
            _context.Doses.Remove(temp);
            _context.SaveChangesAsync();

        }
        public async Task< IEnumerable<Dose>> GetDosesAsync()
        {
            return await _context.Doses.ToListAsync();
        }
        public async Task<Dose> GetDoseByIdAsync(int id)
        {
            return await _context.Doses.FirstAsync(x=>x.DoseId == id);
        }
       public async Task< Dose> UpdateDoseAsync(int id, Dose Dose)
        {
            var temp = await GetDoseByIdAsync(id);
            temp.Price=Dose.Price;
            temp.Name=Dose.Name;
            temp.DoseId=id;
             await _context.SaveChangesAsync();
            return temp;    
       
     
        }

    }
}
