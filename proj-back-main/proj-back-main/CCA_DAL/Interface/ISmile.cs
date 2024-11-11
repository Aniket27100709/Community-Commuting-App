using CCA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA_DAL.Interface
{
    public interface ISmile
    {
        //Task<int> AddSmile(Smile smile);
        Task<List<Smile>> RetrieveSmileBasedOnMonthAndProviderId(int month,string rpId);
    }
}
