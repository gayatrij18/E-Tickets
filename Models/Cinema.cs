using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using E_Tickets.Data.Base;

namespace E_Tickets.Models
{
    public class Cinema:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cinema Logo")]
        [Required(ErrorMessage = "Cinema Logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Cinema Description")]
        [Required(ErrorMessage = "Cinema Description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Movie>? ListedMovies { get; set; }
    }
}
