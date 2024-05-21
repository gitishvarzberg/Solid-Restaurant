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
        Task<IEnumerable<Dose>> GetDosesAsync();
        Task<Dose> GetDoseByIdAsync(int id);
        Task<Dose> AddDoseAsync(Dose Dose);
        Task DeleteDoseAsync(int id);
        Task<Dose> UpdateDoseAsync(int id, Dose Dose);
    }
}
