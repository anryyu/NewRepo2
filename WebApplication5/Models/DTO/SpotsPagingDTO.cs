﻿namespace WebApplication5.Models.DTO
{
    public class SpotsPagingDTO
    {
        public int TotalPages { get; set; }       
        public List<SpotImagesSpot>? SpotsResult { get; set; }
        public List<Category>? CategoryResult { get; set; }

    }
}
