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

//using System;
//namespace MyFirstAPI.Models
//{
//    public class Email
//    {
//        public int EmailId { get; set; }
//        public string EmailAddress { get; set; }
//        public bool IsSubscribed { get; set; }
//    }
//}