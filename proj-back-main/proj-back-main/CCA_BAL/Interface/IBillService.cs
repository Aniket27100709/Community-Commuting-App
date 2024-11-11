using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCA_BAL.DTO;
using CCA_BAL.Result;
using CCA_DAL.Models;

namespace CCA_BAL.Interface
{
    public interface IBillService
    {
        Task<BillDTO> RetrieveBill(int month);
        Task<List<BillDTOs>> generateBillDetails(string tripId);
    }
}
