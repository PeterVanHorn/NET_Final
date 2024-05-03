//Peter Van Horn
//.NET Final Project
//05/03/2024

using System.ComponentModel.DataAnnotations;

namespace VanHorn_NET_Final.Models
{
    public class Credential
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
