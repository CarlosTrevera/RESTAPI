using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTO.restApi.Models
{
    [Table("Content")]
    public class Content
    {
        [Key]
        public Guid ContentId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Url { get; set; }
        [ForeignKey("ContentClassificationId")]
        public Guid ClassificationId { get; set; }
        public ContentClassification Classification { get; set; }
        [ForeignKey("ContentTypeId")]
        public Guid ContentTypeId { get; set; }
        public ContentType ContentType { get; set; }
        [ForeignKey("ContentGenreId")]
        public Guid ContentGenreId { get; set; }
        public ContentGenre ContentGenre { get; set; }


    }
}
