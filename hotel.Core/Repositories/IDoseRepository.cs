using Restaurant.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Restaurant
{
    public interface IDoseRepository
    {
        Task<Dose> AddDoseAsync(Dose Dose);
        void DeleteDose(int id);
        IEnumerable<Dose> GetDoses();
        Dose GetById(int id);
        Dose UpdateDose(int id, Dose Dose);
    }
}
