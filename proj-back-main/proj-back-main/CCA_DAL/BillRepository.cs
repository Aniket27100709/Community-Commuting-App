using CCA_DAL.DBContext;
using CCA_DAL.Interface;
using CCA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCA_DAL.Interface;
using Microsoft.EntityFrameworkCore;

namespace CCA_DAL
{
    public class BillRepository:IBill
    {
        private readonly CCAContext _context;
        public BillRepository(CCAContext context)
        {
            _context = context;
        }
        public async Task<List<billMaster>> GetBill(int month)
        {
            var res = await (from x in _context.billMasters.Include(b=>b.fees) where x.month == month select x).ToListAsync();
            return res;
        }
        public async Task<List<billMaster>> GetBillDetils(string tripId)
        {
            var res = await (from x in _context.billMasters where x.rideId == tripId select x).ToListAsync();
            return res;
        }
    }
}
