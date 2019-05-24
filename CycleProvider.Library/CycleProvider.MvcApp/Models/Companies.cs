using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CycleProvider.MvcApp.Models
{
    public class Companies
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Company without name can not exist")]
        [StringLength(25)]
        public string Name { get; set; }
        public string Decription { get; set; }
        [DisplayName("Year of creation")]
        public int CreationYear { get; set; }
    }
}