using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTO.restApi.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string EmailUser { get; set; }
        [Required(ErrorMessage = "Required")]
        public string PhoneUser { get; set; }
        [Required(ErrorMessage = "Required")]
        public string PassUser { get; set; }
        [Required(ErrorMessage = "Required")]
        public bool Status { get; set; }
        [ForeignKey("MemberId")]
        public Guid MemberId { get; set; }
        public Member Member { get; set; }
    }
}
