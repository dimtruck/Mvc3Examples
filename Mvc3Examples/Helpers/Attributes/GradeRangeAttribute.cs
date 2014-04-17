using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc3Examples.Helpers.Attributes
{
    public class GradeRangeAttribute : ValidationAttribute
    {
        private readonly IEnumerable<String> _range;
        /**
         * we allow a range of grades - comma separated
         */
        public GradeRangeAttribute(String range) : base("{0} is out of range")
        {
            _range = range != null ? range.Split(',').AsEnumerable<String>() : new List<String>();
        }

        /**
         * this method must be overwritten with custom valid logic
         */
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //could be not required so check that the value is passed in first
            if (value != null)
            {
                var valueAsString = value.ToString();
                if(_range == null || !_range.Contains(valueAsString))
                {
                    //value is not in range of allowed grades.  error!
                    var errorMessage = FormatErrorMessage(
                        validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            //we passed!  success!
            return ValidationResult.Success;
       
        }
    }
}