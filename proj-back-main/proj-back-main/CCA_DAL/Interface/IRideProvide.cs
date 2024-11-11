using CCA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA_DAL.Interface
{
    public interface IRideProvide
    {
        Task<List<RideProvide>> GetRider();
        Task<List<RideProvide>> GetRiderDetails(string rpId);
        Task<int> AddRider(RideProvide rideProvide);
        Task<int> UpdateRider(RideProvide rideProvide);
        Task<int> DeleteRider(RideProvide rideProvide);
        Task<RideProvide> FindRideProviderById(string rideProvideId);
    }
}
