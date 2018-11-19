using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AuthApp.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Departent Code")]
        public string DeptCode { get; set; }
        
        [Required]
        [Display(Name = "Campus")]
        public int CampusId { get; set; }
    }
    
}