using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstWebApp.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="First Name is Required")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "last Name is Required")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "PassWord is Required")]
        public string PassWord { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is Required")]
        [DataType(DataType.Password)]
        [Compare("PassWord", ErrorMessage ="Password and confirm Password should match")]
        public string ConfirmPassword { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}