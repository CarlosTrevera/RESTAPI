using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTO.restApi.Models
{
    [Table("ContentClassification")]
    public class ContentClassification
    {
        [Key]
        public Guid ContectClassificationId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string ContentClassificationName { get; set; }

    }
}
