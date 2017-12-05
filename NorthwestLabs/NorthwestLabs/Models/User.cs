using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthwestLabs.Models
{
    [Table("userAccounts")]
    public class User
    {
        [Key]
        public int userID { get; set; }

        [Required(ErrorMessage = "Please enter a username")]
        [DisplayName("Username")]
        [StringLength(30)]
        public String userName { get; set; }
        [Required(ErrorMessage = "Please enter a password")]
        [DisplayName("Password")]
        [StringLength(30)]
        [DataType(DataType.Password)]
        public String userPassword { get; set; }
        public String userType { get; set; }
    }
}