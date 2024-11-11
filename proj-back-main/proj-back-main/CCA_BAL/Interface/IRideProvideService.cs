using CCA_BAL.DTO;
using CCA_BAL.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA_BAL.Interface
{
    public interface IRideProvideService
    {
        Task<List<RideProviderDTO>> getRider();
        Task<List<RideProviderDTO>> getRiderById(string rpId);
        Task<Output> CreateNewRideProvider(RideDTO rideProviderDTO);
        Task<Output> UpdateNewRideProvider(string providerId,UpdateRideProvideDTO rideProviderDTO);
        Task<Output> DeleteRideProvider(string providerId);
        //Task<int> GetSmileReport(SmileDTO smileDTO);
    }
}
