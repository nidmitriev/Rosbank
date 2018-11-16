using System;
using RosbankHelpCenter.API.Models;

namespace RosbankHelpCenter.API.Dtos
{
    public class PhotosForDetailedDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime TimeAdded { get; set; }
        public bool IsMain { get; set; }
    }
}