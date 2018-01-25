using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Adsroid.Models
{
    public class Agency
    {
        [Key]
        public int agency_id { get; set; }

        [Display(Name = "Agency Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Agency Name Required")]
        public string name { get; set; }

        [Display(Name = "Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address Required")]
        public string address { get; set; }

        [Display(Name = "City")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "City Required")]
        public string city { get; set; }

        [Display(Name = "State")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "State Required")]
        public string state { get; set; }

        [Display(Name = "Country")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country Required")]
        public string country { get; set; }

        [Display(Name = "Zipcode")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Zipcode Required")]
        public string zipcode { get; set; }

        [Display(Name = "Website")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Website Address Required")]
        public string website { get; set; }

        [Display(Name = "Contact No")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Contact Number Required")]
        public string contactno { get; set; }

        [Display(Name = "Account Manager Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Account Manager Name is Required")]
        public string username { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Id Required")]
        public string emailid { get; set; }

        [Display(Name = "Skype Id")]
        public string skypeid { get; set; }

        [Display(Name = "Mobile No")]
        [DataType(DataType.PhoneNumber)]
        public string mobileno { get; set; }

        [Display(Name = "Password")]
        [MinLength(6, ErrorMessage = "Minimum 6 Characters Required")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Required")]
        public string password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password didn't match, please check again!")]
        public string ConfirmPassword { get; set; }

    }
}