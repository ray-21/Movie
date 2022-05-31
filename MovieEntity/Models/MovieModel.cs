using System;

namespace MovieEntity
{
    public class MovieModel
    {
      
            public int MovieId { get; set; }
            public string MovieTitle { get; set; }
            public string MovieDescription { get; set; }
            public string MovieType { get; set; }
            public string MovieLanguage { get; set; }
            public byte[] ImgPoster { get; set; }
        }
    }


