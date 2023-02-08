using E_Tickets.Data.Base;
using E_Tickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Tickets.Models
{
    public class NewMovieVM
    {
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Moview name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Movie Description is required")]
        [Display(Name = "Moview Description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Moview Price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Image url is required")]
        [Display(Name = "Moview Image url")]
        public string? ImageURL { get; set; }

        [Required(ErrorMessage = "StartDate is required")]
        [Display(Name = "Moview StartDate")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "EndDate is required")]
        [Display(Name = "Moview EndDate")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "MovieCategory is required")]
        [Display(Name = "MovieCategory")]
        public MovieCategory MovieCategory { get; set; }

        [Required(ErrorMessage = "Actors(s) are required")]
        [Display(Name = "Moview actors")]
        public List<int> ActorIds { get; set; }

        [Required(ErrorMessage = "Cinema is required")]
        [Display(Name = "Moview Cinema")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "Producer is required")]
        [Display(Name = "Moview Producer")]
        public int ProducerId { get; set; }
        
    }
}
