using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCA_DAL.Models;

namespace CCA_DAL.Interface
{
    public interface ITripManage
    {
        Task<int> AddTripDetails(Trip trip);
        Task<List<Trip>> GetTripDetails(string tripId);
        Task<int> UpdateTripDetails(Trip trip);
        Task<Trip> FindTripById(string tripId);
    }
}
