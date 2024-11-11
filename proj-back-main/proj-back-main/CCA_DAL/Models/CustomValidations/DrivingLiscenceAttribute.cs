using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA_DAL.Models.CustomValidations
{
    public class DrivingLiscenceAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            string val=(string)value;
            return val.Length == 16 && val.Count(c => c == '-') == 3;
        }
    }
}
