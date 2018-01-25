using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Adsroid.Models
{
    public class AgencyLogin
    {
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Id Required")]
        public string emailid { get; set; }

        [Display(Name = "Password")]
        [MinLength(6, ErrorMessage = "Minimum 6 Characters Required")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Required")]
        public string password { get; set; }
    }
}