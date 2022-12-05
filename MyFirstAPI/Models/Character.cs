using System;
namespace MyFirstAPI.Models
{
    public class Character
    {
        //[Character("Id")]
        public int CharacterID { get; set; }
        public string FullName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public int DOB { get; set; }
        public string Dragon { get; set; } = null!;
        public int HouseID { get; set; }
    }
}

