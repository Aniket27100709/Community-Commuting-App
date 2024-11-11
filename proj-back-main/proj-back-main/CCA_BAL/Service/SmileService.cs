using CCA_BAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCA_BAL.Result;
using CCA_DAL.Interface;
using CCA_DAL;
using CCA_BAL.DTO;
using CCA_DAL.Models;
namespace CCA_BAL.Service
{
    public class SmileService:ISmileService
    {
        private readonly ISmile _smileRepository;
        public SmileService(ISmile smileRepository)
        {
            _smileRepository = smileRepository;
        }
        public async Task<List<TripDTO>> GetSmile(int month,string rpId)
        {
            
            List<Smile> lists= await _smileRepository.RetrieveSmileBasedOnMonthAndProviderId( month,rpId);
            List<TripDTO> res=new List<TripDTO>();
            foreach(Smile smile in lists)
            {
                if (smile.occupancy >= 0)
                {
                    TripDTO trip = new TripDTO()
                    {
                        month = month,
                        rpId = rpId,
                        source = smile.source,
                        destination = smile.destination,
                        occupancy = smile.occupancy,
                    };
                    res.Add(trip);
                }
            }
            return res;           
        }
    }
}