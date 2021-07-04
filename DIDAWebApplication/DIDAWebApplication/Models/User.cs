using System;
using System.ComponentModel.DataAnnotations;

namespace DIDAWebApplication.Models
{
    public class User
    {
        public string ID { get; set; }
        [Display(Name="เลขบัตรประชาชน/PassportID")]
        public string Citize { get; set; }
        [Display(Name = "ชื่อ - สกุล")]
        public string NameSurname { get; set; }
        [Display(Name = "เบอร์ติดต่อ")]
        public string Telephone { get; set; }
        [Display(Name = "ที่อยู่ต้นทาง")]
        public string Source { get; set; }
        [Display(Name = "ที่อยู่ปลายทาง")]
        public string Destination { get; set; }
    }

    public class AddressSource
    {
        public string SubDistrict { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
    }

    public class AddressDestination
    {
        public string SubDistrict { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
    }

    public class CreatePage
    {
        public User user;
        public AddressSource addressSource;
        public AddressDestination addressDestination;
    }
}
