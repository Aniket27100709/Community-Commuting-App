using CCA_BAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCA_BAL.Result;

namespace CCA_BAL.Interface
{
    public interface ITripService
    {
        Task<Output> CreateTrip(TripBookingDTO tripBookingDTO);
        Task<List<TripBookingDTO>> getTrip(string tripId);

        Task<Output> updateTrip(string tripId,TripBookingDTO tripBookingDTO);
    }
}
