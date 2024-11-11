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
    public class SmileRepository: ISmile
    {
        private readonly CCAContext _context;
        public SmileRepository(CCAContext dbContext)
        {
            _context=dbContext;
        }
        public async Task<int> AddSmile(Smile smile)
        {
           await _context.Smiles.AddAsync(smile);
            int res=await _context.SaveChangesAsync();
            return res;
        }
        public async Task<List<Smile>> RetrieveSmileBasedOnMonthAndProviderId(int month,string rpId)
        {
           var res= await (from x in _context.Smiles where x.month==month && x.rpId==rpId select x).ToListAsync();
            return res;
        }
    }
}
