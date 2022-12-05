using System;
namespace MyFirstAPI.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusDescription { get; set; } = null!;
        List<Character> listOfChar = null!;
        List<House> listOfHouses = null!;
    }
}
