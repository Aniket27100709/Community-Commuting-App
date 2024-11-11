using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA_BAL.DTO
{
    public class RideDTO
    {
        public DateOnly BirthDate { get; set; }
        public long Adharcard { get; set; }
        public string EmailId { get; set; }

        public long Phone { get; set; }

        public string FirstName { get; set; }

        public string lastName { get; set; }

        public string dlNo { get; set; }

        public DateOnly validUpto { get; set; }

        public int age { get; set; }
        public string status { get; set; }
    }
}
