using Azure;
using CCA_DAL.Models.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA_DAL.Models
{
    public class RideProvide
    {
        public string rpId { get; set; }

        [ValueLength(12, ErrorMessage = "Adhaar card must be 12 digits")]
        public long adharcard { get; set; }
        [RegularExpression("^[\\w.+\\-]+@cognizant\\.com$",ErrorMessage = "Email address should always have @cognizant.com")]
        public string emailId { get; set; }

        [ValueLength(10, ErrorMessage = "Phone number must be 10 digits.")]
        public long phone { get; set; }

        [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="First name should have only alphabets")]
        public string firstName { get; set; }

        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Last name should have only alphabets")]
        [StringLength(int.MaxValue,MinimumLength =3,ErrorMessage = "Last name must be minimum 3 characters long.")]
        public string lastName { get; set; }

        [DrivingLiscence(ErrorMessage = "drivingLicenceNumber must be 16 characters long it should including three  hypen(-)")]
        public string dlNo { get; set; }
        public DateOnly validUpto { get; set; }

        [Range(18,int.MaxValue,ErrorMessage = "Age must be minimum of 18.")]
        public int age {  get; set; }
        public DateOnly birthDate { get; set; }
        public string status { get; set; }
        public ICollection<RideInfo> RideInfos { get; set; }
    }
}
