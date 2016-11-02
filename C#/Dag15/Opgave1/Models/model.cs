using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Opgave1.Models
{
    public class model
    {
        [Required(ErrorMessage = "Please enter your age")]
        public string Age { get; set; }
    }
}