using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CCA_DAL.Models.CustomValidations
{
    public class LessThanPropertyAttribute:ValidationAttribute
    {

        string _prop;

        public LessThanPropertyAttribute(string prop)
        {
            this._prop = prop;
        }
        protected override ValidationResult IsValid(object? value, ValidationContext obj)
        {

            int val = (int)value;
            int insVal = (int)obj.ObjectInstance.GetType().GetProperty(this._prop).GetValue(obj.ObjectInstance,null);
            if (val <= insVal) return ValidationResult.Success;
            return new ValidationResult(this.ErrorMessage);
        }
    }
}
