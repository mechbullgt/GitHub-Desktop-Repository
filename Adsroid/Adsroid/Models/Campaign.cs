using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Adsroid.Models
{
    public class Campaign
    {
        [Key]
        public int campaign_id { get; set; }

        [Display(Name = "Campaign Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campaign Name Required")]
        public string cname { get; set; }

        [Display(Name = "Title")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title Required")]
        public string title { get; set; }

        [Display(Name = "Details")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Details Required")]
        public string details { get; set; }

        [Display(Name = "Landing Page")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Landing Page Required")]
        public string landing_page { get; set; }

        [Display(Name = "Payout")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Payout Required")]
        public string payout { get; set; }

        [Display(Name = "KPI")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "KPI Required")]
        public string kpi { get; set; }

        [Display(Name = "Audience")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Audience Required")]
        public string audience { get; set; }

        [Display(Name = "Start Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Start Date Required")]
        public string start_date { get; set; }

        [Display(Name = "End Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "End Date is Required")]
        public string end_date { get; set; }

        [Display(Name = "Budget")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Budget Required")]
        public string budget { get; set; }

        //[Display(Name = "Creative Name")]
        //[Required(AllowEmptyStrings =false,ErrorMessage ="Creative Name Required")]
        //public string creative_name { get; set; }

        //[Display(Name = "Creative Description")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Description Required")]
        //public string creative_description { get; set; }

        //[Display(Name = "Select Creative File")]
        //[RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        //public HttpPostedFile creative { get; set; }

    }
}