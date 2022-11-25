﻿using System;
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
        //public House House { get; set; }
    }
}

//using System;
//namespace MyFirstAPI.Models
//{
//    public class Customer
//    {
//        //[Column("Id")]
//        public int CustomerID { get; set; }
//        public string FirstName { get; set; }
//        public string MiddleName { get; set; }
//        public string LastName { get; set; }
//        public Email? Email { get; set; }
//    }
//}
