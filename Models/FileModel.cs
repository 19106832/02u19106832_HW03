using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _02u19106832_HW03.Models
{
    public class FileModel
    {
        // display options 
        [Display(Name ="File Name")]
        public string FileName { get; set; }
        [Required(ErrorMessage ="Please Select File")]
        [Display(Name ="Browse File")]
        public HttpPostedFileBase[] Files { get; set; }
    }
}