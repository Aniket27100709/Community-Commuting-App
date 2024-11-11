using CCA_BAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA_BAL.Interface
{
    public interface ISmileService
    {
        Task<List<TripDTO>> GetSmile(int month,string rpId);
    }
}
