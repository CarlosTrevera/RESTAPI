using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTO.restApi.Models
{
    [Table("MemberTypeContent")]
    public class MemberTypeContent
    {
        [ForeignKey("MemberTypeId")]
        public Guid MemberTypeId { get; set; }
        [ForeignKey("ContentId")]
        public Guid ContentId { get; set; }
    }
}
