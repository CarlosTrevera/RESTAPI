using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTO.restApi.Models
{
    [Table("MemberTypeContent")]

    public class MemberTypeContent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberTypeContentId { get; set; }
        [ForeignKey("MemberTypeId")]
        public Guid MemberTypeId { get; set; }
        [ForeignKey("ContentId")]
        public Guid ContentId { get; set; }
    }
}
