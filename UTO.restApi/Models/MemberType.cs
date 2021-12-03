using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTO.restApi.Models
{
    [Table("MemberType")]
    public class MemberType
    {
        [Key]
        public Guid MemberTypeId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string MemberName { get; set; }

    }
}
