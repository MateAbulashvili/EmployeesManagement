﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace EmployeesManagement.DAL.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is required")]
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
        [EmailAddress]
        public string Email { get; set; }

        public bool Gender { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        public DateTime DOB { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Status { get; set; }
        public DateTime? FiredDate { get; set; }
        public string Phone { get; set; }
    }
}
