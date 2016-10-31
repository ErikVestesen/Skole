using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Opgave.Models;

namespace Opgave.Models
{
    public class myClasses
    {
        [Required(ErrorMessage = "Please enter your age")]
        public string Age { get; set; }
    }
}