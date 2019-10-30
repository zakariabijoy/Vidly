﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:255)]
        public string Name { get; set; }
        
        public Genre Genre { get; set; }
        
        [Required]
        [Display(Name ="Genre")]
        public int GenreId { get; set; }
        
        [Display(Name = "Release Data")]
        [Required]
        
        public DateTime? ReleaseDate { get; set; } 
 
        public DateTime? DateAdded { get; set; }
        
        [Display(Name = "Number In Stock")]
        [Required]
        [Range(1,20)]
        public int? NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }   
        

    }
}