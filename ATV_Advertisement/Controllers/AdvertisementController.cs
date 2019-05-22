using DataService.Model;
using DataService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Advertisement.Controllers
{
    public class AdvertisementController
    {
        private readonly AdvertisementService _advertisementService;

        public AdvertisementController()
        {
            _advertisementService = new AdvertisementService();
        }

        public Advertisment GetById(int id)
        {
            return _advertisementService.GetById(id);
        }
    }
}
