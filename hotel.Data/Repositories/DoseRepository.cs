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
        async Task<Dose> IDoseRepository.AddDoseAsync(Dose Dose) 
        {
            _context.Doses.Add(Dose);
            
            await _context.SaveChangesAsync();
            return Dose;
        }
        void IDoseRepository.DeleteDose(int id)
        { 
            //
            var temp = _context.Doses.Find(id);
            _context.Doses.Remove(temp);
            _context.SaveChanges();

        }
        IEnumerable<Dose> IDoseRepository.GetDoses()
        {
            return _context.Doses;

        }
        Dose IDoseRepository.GetById(int id)
        {
            return _context.Doses.Find(id);
        }
        Dose IDoseRepository.UpdateDose(int id, Dose Dose)
        {
            var temp = _context.Doses.Find(id);
            temp.Price=Dose.Price;
            temp.Name=Dose.Name;
            temp.DoseId=id;
       
            
            _context.SaveChanges();
            return temp;
        }

        

    }
}
