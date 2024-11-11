using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA_DAL.Models.CustomValidations
{
    public class ValueLengthAttribute:ValidationAttribute
    {
        private long _length;
        public ValueLengthAttribute() { }
        public ValueLengthAttribute(long length) 
        {
            _length=length;
        }

        public override bool IsValid(object? value)
        {
            string val = value.ToString();
            if (val.Length == _length) {
                return true;
            }
            return false;
        }
    }
}