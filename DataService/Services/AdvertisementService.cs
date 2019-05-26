using DataService.Model;
using DataService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Services
{
    public interface IAdvertisementService
    {
        Advertisement GetById(int id);
    }

    public class AdvertisementService : IAdvertisementService
    {
        private readonly AdvertisementRepository _advertismentRepository;

        public AdvertisementService()
        {
            _advertismentRepository = new AdvertisementRepository();
        }

        public Advertisement GetById(int id)
        {
            return _advertismentRepository.GetById(id);
        }
    }
}
