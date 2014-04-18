using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc3Examples.Models
{
    public class AccountModel
    {
        [Required]
        public String Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        public String Role { get; set; }
        
    }
}