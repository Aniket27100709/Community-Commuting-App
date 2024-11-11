using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCA_DAL.Models;

namespace CCA_DAL.Interface
{
    public interface IBill
    {
        Task<List<billMaster>> GetBill(int month);
        Task<List<billMaster>> GetBillDetils(string tripId);
    }
}
