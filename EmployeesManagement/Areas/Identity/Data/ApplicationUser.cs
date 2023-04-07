using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EmployeesManagement.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName ="nvarchar(100)")]
        public string PersonalNumber { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string LastName { get; set; }

        [PersonalData]
        [Column(TypeName = "datetime2(7)")]
        public DateTime DOB { get; set; }

        [PersonalData]
        public string Gender { get; set; }

    }
}
