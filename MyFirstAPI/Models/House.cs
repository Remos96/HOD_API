using System;
namespace MyFirstAPI.Models
{
    public class House
    {
        public int HouseID { get; set; }
        public string HouseName { get; set; } = null!;
        public string Slogan { get; set; } = null!;
    }
}
