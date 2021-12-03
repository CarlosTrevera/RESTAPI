using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTO.restApi.Models
{
    [Table("Member")]
    public class Member
    {
        [Key]
        public Guid MemberId { get; set; }
        [Required(ErrorMessage = "Required")]
        public DateTime VigencyMember { get; set; }
        [ForeignKey("MemberTypeId")]
        public Guid MemberTypeId { get; set; }

    }
}
