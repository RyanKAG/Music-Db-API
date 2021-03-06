using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace personalAPI.Models
{
    public class Artist : IModel
    {
        public int Id { get; set; } 
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MinLength(8)]
        public string password { get; set; }

        public IEnumerable<Album> Albums { get; set; }
    }
}