using System;
using System.ComponentModel.DataAnnotations;

namespace burgers.Models
{
    public class Burger
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        public float price { get; set; }

    }
}