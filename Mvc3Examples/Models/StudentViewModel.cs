using Mvc3Examples.Helpers.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc3Examples.Models
{
    public class StudentViewModel
    {
        [Required]
        public String Name { get; set; }

        [StringLength(10,MinimumLength=5)]
        public String Address { get; set; }

        [RegularExpression(@"\d{5}", ErrorMessage="Zip code must be 5 digits")]
        public String ZipCode { get; set; }

        [Range(18, 120)]
        public int Age { get; set; }

        [Remote("ValidateSchool","Attributes",ErrorMessage="unable to find the school entered")]
        public String School { get; set; }

        //this is a custom validation implemented in Helpers.Attributes
        [GradeRange("A,B,C,D,F", ErrorMessage="not a valid grade")]
        public String Grade { get; set; }

        [GradeRangeClient("A,B,C,D,F", ErrorMessage = "not a valid grade")]
        public String GradeClient { get; set; }
    }
}