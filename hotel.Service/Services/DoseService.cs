using Restaurant.Core.Models;
using Restaurant.Core.Repositories;
using Restaurant.Core.Restaurant;
using Restaurant.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service.Services
{
    public class DoseService:IDoseService
    {
        private readonly IDoseRepository _doseRepository;
        public DoseService(IDoseRepository doseRepository)
        {
            _doseRepository = doseRepository;
        }
        async Task< Dose>  IDoseService.AddDoseAsync(Dose Dose)
        {
           return await _doseRepository.AddDoseAsync(Dose);
           
        }

        public async Task<IEnumerable<Dose>> GetDosesAsync()
        {
            return await _doseRepository.GetDosesAsync();   
        }

        public async Task<Dose> GetDoseByIdAsync(int id)
        {
            return await _doseRepository.GetDoseByIdAsync(id);   
        }

        public async Task DeleteDoseAsync(int id)
        {
            await _doseRepository.DeleteDoseAsync(id);  
        }

        public async Task<Dose> UpdateDoseAsync(int id, Dose Dose)
        {
            return await _doseRepository.UpdateDoseAsync(id, Dose);   
        }
    }
}
