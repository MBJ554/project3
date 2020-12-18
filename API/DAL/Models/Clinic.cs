﻿namespace API.DAL.Models
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
        public string PhoneNo { get; set; }
        public string Description { get; set; }

        public Clinic()
        {
        }
    }
}