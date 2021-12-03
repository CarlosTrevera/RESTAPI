using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTO.restApi.Models
{
    [Table("ContentGenre")]
    public class ContentGenre
    {
        [Key]
        public Guid ContentGenreId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string ContentGenreName { get; set; }

    }
}
