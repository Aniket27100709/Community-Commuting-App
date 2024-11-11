using CCA_DAL.DBContext;
using CCA_DAL.Interface;
using CCA_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CCA_DAL
{
    public class RideProvideRepository: IRideProvide
    {
        private readonly CCAContext _dbContext;

        public RideProvideRepository(CCAContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<RideProvide>> GetRider()
        {
           return await _dbContext.RideProvides.ToListAsync();
        }
        public async Task<List<RideProvide>> GetRiderDetails(string rpId)
        {
            var res = await (from x in _dbContext.RideProvides where x.rpId == rpId select x).ToListAsync();
            return res;
        }
        public async Task<int> AddRider(RideProvide rideProvide)
        {
                try
                {    
                    await _dbContext.RideProvides.AddAsync(rideProvide);
                    int ret = await _dbContext.SaveChangesAsync();

                    return ret;
                }
                catch (Exception ex)
                {
                    throw;
                }   
        }

        public async Task<int> UpdateRider(RideProvide rideProvide)
        {
                _dbContext.Entry(rideProvide).State = EntityState.Modified;
                int ret=await _dbContext.SaveChangesAsync();
                return ret;
        }
        public async Task<RideProvide?> FindRideProviderById(string rideProvideId)
        {
            try
            {
                var result=await _dbContext.RideProvides.FindAsync(rideProvideId);
                return result;
            }
            catch(Exception ex) {
                throw;
            }
        }
        public async Task<int> DeleteRider(RideProvide rideProvide)
        {
            _dbContext.Remove(rideProvide);
            int res= await _dbContext.SaveChangesAsync();
            return res;
        }

    }


    


}
