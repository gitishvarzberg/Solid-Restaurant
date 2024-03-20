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

        public void DeleteDose(int id)
        {
            _doseRepository.DeleteDose(id);
        }

        IEnumerable<Dose> IDoseService.GetDoses()
        {
            return _doseRepository.GetDoses();
        }

        Dose IDoseService.GetById(int id)
        {
            return _doseRepository.GetById(id);
        }

        Dose IDoseService.UpdateDose(int id, Dose dose)
        {
            return _doseRepository.UpdateDose(id, dose);
        }
    }
}
