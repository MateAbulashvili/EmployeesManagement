using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeesManagement.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [MaxLength(11)]
        [MinLength(11, ErrorMessage = "Number must be 11 digits")]
        [DisplayName("Personal Number")]

        public string PersonalNumber { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Password { get; set; }
        public bool Gender { get; set; }

        [DisplayFormat(DataFormatString ="{0:MMM-dd-yy}")]
        public DateTime DOB { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public DateTime? FiredDate { get; set; }
        public string Phone { get; set; }
    }
}
