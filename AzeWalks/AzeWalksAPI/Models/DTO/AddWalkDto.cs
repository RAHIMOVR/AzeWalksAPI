﻿namespace AzeWalksAPI.Models.DTO
{
    public class AddWalkDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LenghtInKm { get; set; }
        public string WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
    }
}
