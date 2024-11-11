using CCA_DAL.DBContext;
using CCA_DAL.Interface;
using CCA_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA_DAL
{
    public class TripManageRepository:ITripManage
    {
        private readonly CCAContext _context;
        public TripManageRepository(CCAContext context) { 
           _context = context;
        }
        public async Task<int> AddTripDetails(Trip trip)
        {
            try
            {
                await _context.Trips.AddAsync(trip);
                int ret = await _context.SaveChangesAsync();
                return ret;
            }
            catch (Exception ex) {
                throw;
            }
        }
        public async Task<List<Trip>> GetTripDetails(string tripId)
        {
            var res = await (from x in _context.Trips where x.tripId == tripId select x).ToListAsync();
            return res;
        }
        public async Task<int> UpdateTripDetails(Trip trip)
        {
            _context.Entry(trip).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        public async Task<Trip?> FindTripById(string tripId){
            try
            {
                var ret = await _context.Trips.FindAsync(tripId);
                return ret;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
