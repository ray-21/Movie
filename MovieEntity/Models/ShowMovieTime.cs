using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace MovieEntity.Models
{
    public class ShowMovieTime
    {
           [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int MovieTimeId { get; set; }


            [ForeignKey("movieModel")]
            public int MovieId { get; set; }

        public MovieModel movieModel { get; set; }

        [ForeignKey("threaterModel")]
        public int ThetreId { get; set; }

        public ThreaterModel ThetreModel { get; set; }

        public string ShowTime { get; set; }

        public string Date { get; set; }
    
    }
	}


