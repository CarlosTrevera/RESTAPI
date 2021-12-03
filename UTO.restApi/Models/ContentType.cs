using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTO.restApi.Models
{
    [Table("ContentType")]
    public class ContentType
    {
        [Key]
        public Guid ContentTypeId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string ContentTypeName { get; set; }
    }
}
