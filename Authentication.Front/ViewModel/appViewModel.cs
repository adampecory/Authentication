using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//using System.Web.Mvc;

namespace Authentication.Front.ViewModel
{
    public class appViewModel
    {
    }

    public class RoleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Login is required")]
        [StringLength(30, MinimumLength=4, ErrorMessage="Le login comprend au minimum 4 charactères")]
        public string Login { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"\d{10}", ErrorMessage = "Invalid Phone Number!")]
        [DataType(DataType.PhoneNumber)]
        public string Tel { get; set; }
    }

    public class UserRoleVM
    {
        public IEnumerable<System.Web.Mvc.SelectListItem> Users {get; set;}
        public IEnumerable<System.Web.Mvc.SelectListItem> Roles { get; set; }
        public int[] SelectedUsers { get; set; }
        public int[] SelectedRoles { get; set; }
    }
}